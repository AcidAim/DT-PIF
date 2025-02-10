using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using XE908.Areas.Identity.Data;
using XE908.Data;
using XE908.Models;
using Controller = XE908.Models.Controller;

namespace XE908.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly UserManager<XE908User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(DataContext context, UserManager<XE908User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<XE908User>> GetAllUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        return users;
    }

    public async Task<ServiceResponse<string>> GetRfidBadge(XE908User user)
    {
        var serviceResponse = new ServiceResponse<string>();
        try
        {
            var selectedUser = await _context.Users.FirstAsync(u => u.Id == user.Id);
            serviceResponse.Data = selectedUser.RFID_Batch;
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> CheckIfUserIsAdminByBadgeAsync(string rfidBadge)
    {
        var serviceResponse = new ServiceResponse<string>();
        try
        {
            var user = await _userManager.Users.FirstAsync(u => u.RFID_Batch == rfidBadge);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains("Administrator"))
            {
                serviceResponse.Success = false;
            }
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<XE908User>> SetRfidBadge(XE908User user, string batchId)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            var selectedUser = await _context.Users.FirstAsync(u => u.Id == user.Id);
            selectedUser.RFID_Batch = batchId;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<XE908User>> SetUserName(XE908User user, string userName)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            var selectedUser = await _context.Users.FirstAsync(u => u.Id == user.Id);
            selectedUser.UserName = userName;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<XE908User>> SetEmail(XE908User user, string email)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            await _userManager.SetEmailAsync(user, email);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<string> GetFirstName(XE908User user)
    {
        try
        {
            var selectedUser = await _context.Users.FirstAsync(u => u == user);
            return selectedUser.FirstName;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<ServiceResponse<XE908User>> GetUserByUserName(string username)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            serviceResponse.Data = await _userManager.Users.FirstAsync(u => u.UserName == username);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        

        return serviceResponse;
    }

    public async Task<ServiceResponse<XE908User>> GetUserById(string userId)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            serviceResponse.Data = await _userManager.Users.FirstAsync(u => u.Id == userId);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<XE908User>> DeleteUser(string userId)
    {
        var serviceResponse = new ServiceResponse<XE908User>();
        try
        {
            var selectedUser = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(selectedUser);
        }
        catch (Exception e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }
}