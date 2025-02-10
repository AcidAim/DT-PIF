using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Services.RoleService;

namespace XE908.Pages.Admin.Roles
{
    [Authorize(Roles = "Administrator")]
    public class CreateRolesModel : PageModel
    {
        private readonly ILogger<CreateRolesModel> _logger;
        private readonly IRoleService _roleService;


        public CreateRolesModel(ILogger<CreateRolesModel> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Role Name")]
            public string RoleName { get; set; }
        }
        public void OnGet()
        {
            Input = new InputModel()
            {
                RoleName = string.Empty
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _roleService.CreateRoleAsync(Input.RoleName);
            return RedirectToPage();
        }
    }
}
