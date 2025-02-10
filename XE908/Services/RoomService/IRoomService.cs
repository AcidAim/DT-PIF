using XE908.Dtos.ConferenceRoomDto;
using XE908.Models;

namespace XE908.Services.RoomService;

public interface IRoomService
{
    public Task<ServiceResponse<List<ConferenceRoom>>> GetAllConferenceRoomsAsync();
    public Task<ServiceResponse<ConferenceRoom>> GetConferenceRoomById(int conferenceRoomId);
    public Task<ServiceResponse<ConferenceRoom>> CreateConferenceRoomAsync(AddConferenceRoomDto conferenceRoomDto);
    public Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomDescriptionAsync(string conferenceRoomDescription, int conferenceRoomId);
    public Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomNumberAsync(string conferenceRoomNumber, int conferenceRoomId);
    public Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomCapacityAsync(int conferenceRoomCapacity, int conferenceRoomId);
}