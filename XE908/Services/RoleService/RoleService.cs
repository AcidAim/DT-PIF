using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XE908.Areas.Identity.Data;
using XE908.Data;

namespace XE908.Services.RoleService;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<XE908User> _userManager;
    private readonly DataContext _context;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<XE908User> userManager, DataContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<List<IdentityRole>> GetAllRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task CreateRoleAsync(string name)
    {
        await _roleManager.CreateAsync(new IdentityRole(name));
    }

    public async Task DeleteRoleAsync(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);
        await _roleManager.DeleteAsync(role!);
    }

    public async Task AddUserToRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.AddToRoleAsync(user!, roleName);
    }

    public async Task RemoveUserFromRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.RemoveFromRoleAsync(user!, role);
    }
}