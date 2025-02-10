using XE908.Models;

namespace XE908.Services.ControllerService;

public interface IControllerService
{
    public Task<ServiceResponse<List<Controller>>> GetAllControllersAsync();
    public Task<ServiceResponse<List<Controller>>> GetAllAvailableControllersAsync();
    public Task<ServiceResponse<Controller>> GetControllerByHostNameAsync(string controllerHostName);
    public Task<ServiceResponse<Controller>> CreateControllerAsync(string hostName);
}