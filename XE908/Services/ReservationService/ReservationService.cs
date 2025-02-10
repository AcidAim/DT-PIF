using Microsoft.EntityFrameworkCore;
using XE908.Areas.Identity.Data;
using XE908.Data;
using XE908.Dtos.ReservationDto;
using XE908.Models;

namespace XE908.Services.ReservationService;

public class ReservationService : IReservationService
{
    private readonly DataContext _context;

    public ReservationService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Reservation>>> GetAllReservationsFromUserAsync(string badgeId)
    {
        var serviceResponse = new ServiceResponse<List<Reservation>>();
        try
        {
            var selectedUser = await _context.Users.Where(u => u.RFID_Batch == badgeId)
                .Include(u=>u.Reservations)
                .ThenInclude(r=>r.ConferenceRoom).FirstAsync();
            serviceResponse.Data = selectedUser.Reservations;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Reservation>>> GetAllReservationsFromRoomAsync(int roomId)
    {
        var serviceResponse = new ServiceResponse<List<Reservation>>();
        try
        {
            serviceResponse.Data = await _context.Reservations.Where(r=>r.ConferenceRoom.Id == roomId).ToListAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<Reservation>> CreateReservationAsync(AddReservationDto reservationDto)
    {
        var serviceResponse = new ServiceResponse<Reservation>();
        try
        {
            var reservation = reservationDto.ReservationDtoToReservation();
            reservation.User = await _context.Users.FirstAsync(u => u.Id == reservationDto.UserId);
            reservation.ConferenceRoom =
                await _context.ConferenceRooms.FirstAsync(r => r.Id == reservationDto.ConferenceRoomId);
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }
}