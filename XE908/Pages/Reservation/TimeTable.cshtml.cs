using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Areas.Identity.Data;
using XE908.Models;
using XE908.Services.ReservationService;

namespace XE908.Pages.Reservation;

[Authorize]
public class TimeTableModel : PageModel
{
    private readonly IReservationService _reservationService;
    private readonly UserManager<XE908User> _userManager;

    public TimeTableModel(IReservationService reservationService, UserManager<XE908User> userManager)
    {
        _reservationService = reservationService;
        _userManager = userManager;
        Events = new List<FullCalendarEvent>();
    }

    public string? CurrentUserId { get; set; }
    public int? RoomId { get; set; }
    public List<Models.Reservation>? Reservations { get; set; }
    public List<FullCalendarEvent> Events { get; set; }

    public async Task OnGetAsync(int? roomIdUrlParam)
    {
        RoomId = roomIdUrlParam;
        if (RoomId != null)
        {
            Reservations = (await _reservationService.GetAllReservationsFromRoomAsync((int)RoomId)).Data;
            if (Reservations != null)
                foreach (var reservation in Reservations)
                    Events.Add(new FullCalendarEvent
                    {
                        title = reservation.ReservationPurpose,
                        start = reservation.ReservationStart.ToString("s"),
                        end = reservation.ReservationEnd.ToString("s")
                    });

            CurrentUserId = _userManager.GetUserId(User);
        }
    }
}