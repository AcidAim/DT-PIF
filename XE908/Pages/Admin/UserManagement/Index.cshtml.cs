using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Areas.Identity.Data;
using XE908.Services.UserService;

namespace XE908.Pages.Admin.UserManagement
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public InputModel? Input { get; set; }
        [BindProperty]
        public XE908User? Client { get; set; }
        public class InputModel
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EMail { get; set; }
            public string RfidBatch { get; set; }
        }
        
        public async Task OnGetAsync(string? clientId)
        {
            if (clientId != null)
            {
                Client = (await _userService.GetUserById(clientId)).Data;
                Input = new InputModel()
                {
                    EMail = Client.Email,
                    FirstName = Client.FirstName,
                    LastName = Client.LastName,
                    RfidBatch = Client.RFID_Batch,
                    UserName = Client.UserName
                };
            }
        }

        public async Task<IActionResult> OnPostAsync(string? clientId)
        {
            Client = (await _userService.GetUserById(clientId)).Data;
            if (Client.Email != Input.EMail)
            {
                await _userService.SetEmail(Client, Input.EMail);
            }

            if (Client.RFID_Batch != Input.RfidBatch)
            {
                await _userService.SetRfidBadge(Client, Input.RfidBatch);
            }

            if (Client.UserName != Input.UserName)
            {
                await _userService.SetUserName(Client, Input.UserName);
            }

            return RedirectToPage("../Index");
        }

    }
}
