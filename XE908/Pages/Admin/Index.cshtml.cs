using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Areas.Identity.Data;
using XE908.Services.UserService;

namespace XE908.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<XE908User> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _userService.GetAllUsersAsync();
        }

        public void OnGetTest()
        {
            Console.WriteLine("Success");
        }
    }
}
