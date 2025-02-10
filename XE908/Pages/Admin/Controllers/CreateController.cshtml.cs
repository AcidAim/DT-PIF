using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Data;
using XE908.Services.ControllerService;

namespace XE908.Pages.Admin.Controllers
{
    public class CreateControllerModel : PageModel
    {
        private readonly IControllerService _controllerService;

        public CreateControllerModel(IControllerService controllerService)
        {
            _controllerService = controllerService;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required] public string HostName { get; set; }
        }
        public async Task OnGetAsync()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _controllerService.CreateControllerAsync(Input.HostName);

            return Page();
        }
    }
}
