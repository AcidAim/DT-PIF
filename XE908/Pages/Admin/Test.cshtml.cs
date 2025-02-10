using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Services.ControllerService;
using Controller = XE908.Models.Controller;

namespace XE908.Pages.Admin
{
    public class TestModel : PageModel
    {
        private readonly IControllerService _controllerService;

        public TestModel(IControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        public List<Controller>? Controllers { get; set; }
        public async Task OnGetAsync()
        {
            Controllers = (await _controllerService.GetAllAvailableControllersAsync()).Data;
        }
    }
}
