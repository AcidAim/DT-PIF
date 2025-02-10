using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using XE908.Data;
using XE908.Models;

namespace XE908.Services.ControllerService;

public class ControllerService : IControllerService
{
    private readonly DataContext _context;

    public ControllerService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Controller>>> GetAllControllersAsync()
    {
        var serviceResponse = new ServiceResponse<List<Controller>>();
        try
        {
            serviceResponse.Data = await _context.Controllers.ToListAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Controller>>> GetAllAvailableControllersAsync()
    {
        var serviceResponse = new ServiceResponse<List<Controller>>();
        try
        {
            serviceResponse.Data = await _context.Controllers.Where(c => c.ConferenceRoom == null).ToListAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<Controller>> GetControllerByHostNameAsync(string controllerHostName)
    {
        var serviceResponse = new ServiceResponse<Controller>();
        try
        {
            serviceResponse.Data = await _context.Controllers.FirstAsync(c => c.HostName == controllerHostName);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<Controller>> CreateControllerAsync(string hostName)
    {
        var serviceResponse = new ServiceResponse<Controller>();
        try
        {
            var newController = new Controller() { HostName = hostName, NormalizedHostName = hostName.ToUpper() };
            await _context.Controllers.AddAsync(newController);
            await _context.SaveChangesAsync();
            serviceResponse.Data = newController;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }
}