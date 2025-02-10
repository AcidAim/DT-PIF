using XE908.Models;

namespace XE908.Dtos.ConferenceRoomDto;

public class AddConferenceRoomDto
{
    public string RoomNumber { get; set; }
    public string RoomDescription { get; set; }
    public int Capacity { get; set; }
    public string ControllerId { get; set; }
    public Controller Controller { get; set; }
}