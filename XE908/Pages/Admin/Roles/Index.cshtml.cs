using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XE908.Services.RoleService;

namespace XE908.Pages.Admin.Roles
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        public List<IdentityRole> Roles { get; set; }
        private readonly IRoleService _roleService; 
        private readonly RoleManager<IdentityRole> _roleManager; 
        public IndexModel(IRoleService roleService, RoleManager<IdentityRole> roleManager) 
        {
            _roleService = roleService;
            _roleManager = roleManager;
        }

        [TempData] 
        public string StatusMessage { get; set; }
        
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string DeletedRoleId { get; set; }
        }

        public async Task LoadAsync()
        {
            Roles = await _roleService.GetAllRolesAsync();
            Input = new InputModel()
            { 
                DeletedRoleId = ""
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
                await _roleService.DeleteRoleAsync(Input.DeletedRoleId);
            }
            catch (Exception e)
            {
                StatusMessage = "Error occurred while deleting a role.";
            }
            
            return RedirectToPage();
        }
    }
    
}
