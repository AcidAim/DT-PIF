using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XE908.Pages.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ModifyControllerModel : PageModel
    {
        public string ControllerId { get; set; }
        public void OnGet(string controllerId)
        {
            ControllerId = controllerId;
        }
    }
}
