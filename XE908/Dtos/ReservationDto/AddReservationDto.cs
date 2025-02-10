namespace XE908.Dtos.ReservationDto;

public class AddReservationDto
{
    public string ReservedOnTime { get; set; } 
    public string ReservationStart { get; set; }
    public string ReservationEnd { get; set; }
    public string ReservationPurpose { get; set; }
    public string UserId { get; set; }
    public int ConferenceRoomId { get; set; }
}