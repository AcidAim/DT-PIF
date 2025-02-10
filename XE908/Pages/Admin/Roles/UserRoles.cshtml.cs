using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Areas.Identity.Data;
using XE908.Services.RoleService;
using XE908.Services.UserService;

namespace XE908.Pages.Admin.Roles
{
    [Authorize(Roles = "Administrator")]
    public class UserRolesModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public List<XE908User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public UserRolesModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [TempData]
        public string StatusMessage { get; set; }
        
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string ModifiedUserId { get; set; } = null!;
            public string ModifiedRoleName { get; set; } = null!;
            public string RoleAction { get; set; } = null!;
        }
        public async Task LoadAsync()
        {
            Users = await _userService.GetAllUsersAsync();
            Roles = await _roleService.GetAllRolesAsync();
            Input = new InputModel()
            {
                ModifiedRoleName = "",
                ModifiedUserId = "",
                RoleAction = ""
            };
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                switch (Input.RoleAction)
                { 
                    case "AddToRole": 
                        await _roleService.AddUserToRoleAsync(Input.ModifiedUserId, Input.ModifiedRoleName); 
                        break;
                    case "RemoveFromRole": 
                        await _roleService.RemoveUserFromRoleAsync(Input.ModifiedUserId, Input.ModifiedRoleName); 
                        break;
                }
            }
            catch (Exception e)
            {
                StatusMessage = "Error when trying to modify user roles.";
                return RedirectToPage();
            }
            
            return RedirectToPage();
        }
    }
}
