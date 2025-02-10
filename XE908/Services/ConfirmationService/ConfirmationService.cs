using XE908.Data;
using XE908.Models;
using XE908.Services.ReservationService;
using XE908.Services.UserService;

namespace XE908.Services.ConfirmationService;

public class ConfirmationService : IConfirmationService
{
    private readonly DataContext _context;
    private readonly IReservationService _reservationService;
    private readonly IUserService _userService;

    public ConfirmationService(IUserService userService, DataContext context, IReservationService reservationService)
    {
        _userService = userService;
        _context = context;
        _reservationService = reservationService;
    }

    public async Task<ServiceResponse<Reservation>> IsClientAllowed(string badgeId, int roomId)
    {
        var serviceResponse = new ServiceResponse<Reservation>
        {
            Success = false
        };
        try
        {
            if (!(await _userService.CheckIfUserIsAdminByBadgeAsync(badgeId)).Success)
            {
                var reservations = (await _reservationService.GetAllReservationsFromUserAsync(badgeId)).Data;
                foreach (var reservation in reservations!
                             .Where(reservation =>
                                 DateTime.Now >= reservation.ReservationStart &&
                                 DateTime.Now < reservation.ReservationEnd).Where(reservation =>
                                 reservation.ConferenceRoom.Id == roomId))
                {
                    serviceResponse.Success = true;
                    serviceResponse.Data = reservation;
                }
            }
            else
            {
                serviceResponse.Success = true;
            }

            
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }
}