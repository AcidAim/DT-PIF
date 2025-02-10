using Microsoft.AspNetCore.Identity;
using XE908.Areas.Identity.Data;
using XE908.Models;

namespace XE908.Services.UserService;

public interface IUserService
{
    public Task<List<XE908User>> GetAllUsersAsync();
    public Task<ServiceResponse<string>> GetRfidBadge(XE908User user);
    public Task<ServiceResponse<string>> CheckIfUserIsAdminByBadgeAsync(string rfidBadge);
    public Task<ServiceResponse<XE908User>> SetRfidBadge(XE908User user, string batchId);
    public Task<ServiceResponse<XE908User>> SetUserName(XE908User user, string userName);
    public Task<ServiceResponse<XE908User>> SetEmail(XE908User user, string email);
    public Task<string> GetFirstName(XE908User user);
    public Task<ServiceResponse<XE908User>> GetUserByUserName(string username);
    public Task<ServiceResponse<XE908User>> GetUserById(string userId);
    public Task<ServiceResponse<XE908User>> DeleteUser(string userId);
}