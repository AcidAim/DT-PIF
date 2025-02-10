using XE908.Areas.Identity.Data;
using XE908.Dtos.ReservationDto;
using XE908.Models;

namespace XE908.Services.ReservationService;

public interface IReservationService
{
    public Task<ServiceResponse<List<Reservation>>> GetAllReservationsFromUserAsync(string badgeId);
    public Task<ServiceResponse<List<Reservation>>> GetAllReservationsFromRoomAsync(int roomId);
    public Task<ServiceResponse<Reservation>> CreateReservationAsync(AddReservationDto reservationDto);
}