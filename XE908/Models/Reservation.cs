using XE908.Areas.Identity.Data;

namespace XE908.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateOnly ReservedOnTime { get; set; }
    public DateTime ReservationStart { get; set; }
    public DateTime ReservationEnd { get; set; }
    public string ReservationPurpose { get; set; } = null!;
    public XE908User User { get; set; } = null!;
    public ConferenceRoom ConferenceRoom { get; set; } = null!;
}