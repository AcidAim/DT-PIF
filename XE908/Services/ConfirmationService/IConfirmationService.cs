using XE908.Models;

namespace XE908.Services.ConfirmationService;

public interface IConfirmationService
{
    public Task<ServiceResponse<Reservation>> IsClientAllowed(string badgeId, int roomId);
}