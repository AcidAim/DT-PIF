using Microsoft.AspNetCore.Identity;
using XE908.Areas.Identity.Data;

namespace XE908.Services.RoleService;

public interface IRoleService
{
    public Task<List<IdentityRole>> GetAllRolesAsync();
    public Task CreateRoleAsync(string name);
    public Task DeleteRoleAsync(string roleId);
    public Task AddUserToRoleAsync(string userId, string role);
    public Task RemoveUserFromRoleAsync(string userId, string role);
}