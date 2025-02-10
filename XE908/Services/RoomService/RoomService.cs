using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XE908.Controllers;
using XE908.Data;
using XE908.Dtos.ConferenceRoomDto;
using XE908.Models;

namespace XE908.Services.RoomService;

public class RoomService : IRoomService
{
    private readonly DataContext _context;

    public RoomService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<ConferenceRoom>>> GetAllConferenceRoomsAsync()
    {
        var serviceResponse = new ServiceResponse<List<ConferenceRoom>>();
        try
        {
            serviceResponse.Data = await _context.ConferenceRooms.Include(cr => cr.Controller).ToListAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ConferenceRoom>> GetConferenceRoomById(int conferenceRoomId)
    {
        var serviceResponse = new ServiceResponse<ConferenceRoom>();
        try
        {
            serviceResponse.Data = await _context.ConferenceRooms.Include(cr => cr.Controller)
                .FirstAsync(cr => cr.Id == conferenceRoomId);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ConferenceRoom>> CreateConferenceRoomAsync(AddConferenceRoomDto conferenceRoomDto)
    {
        var serviceResponse = new ServiceResponse<ConferenceRoom>();
        try
        {
            var newConferenceRoom = conferenceRoomDto.ConferenceRoomDtoToConferenceRoom();
            await _context.ConferenceRooms.AddAsync(newConferenceRoom);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomDescriptionAsync(string conferenceRoomDescription, int conferenceRoomId)
    {
        var serviceResponse = new ServiceResponse<ConferenceRoom>();
        try
        {
            var conferenceRoom = await _context.ConferenceRooms.Include(cr => cr.Controller)
                .FirstAsync(cr => cr.Id == conferenceRoomId);
            conferenceRoom.RoomDescription = conferenceRoomDescription;
            await _context.SaveChangesAsync();
            serviceResponse.Data = conferenceRoom;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomNumberAsync(string conferenceRoomNumber, int conferenceRoomId)
    {
        var serviceResponse = new ServiceResponse<ConferenceRoom>();
        try
        {
            var conferenceRoom = await _context.ConferenceRooms.Include(cr => cr.Controller)
                .FirstAsync(cr => cr.Id == conferenceRoomId);
            conferenceRoom.RoomNumber = conferenceRoomNumber;
            await _context.SaveChangesAsync();
            serviceResponse.Data = conferenceRoom;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ConferenceRoom>> SetConferenceRoomCapacityAsync(int conferenceRoomCapacity, int conferenceRoomId)
    {
        var serviceResponse = new ServiceResponse<ConferenceRoom>();
        try
        {
            var conferenceRoom = await _context.ConferenceRooms.Include(cr => cr.Controller)
                .FirstAsync(cr=>cr.Id == conferenceRoomId);
            conferenceRoom.Capacity = conferenceRoomCapacity;
            await _context.SaveChangesAsync();
            serviceResponse.Data = conferenceRoom;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }
    
}