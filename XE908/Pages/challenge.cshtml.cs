using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Controllers;
using XE908.Services.ConfirmationService;

namespace XE908.Pages
{
    public class challengeModel : PageModel
    {
        private readonly IConfirmationService _confirmationService;

        public challengeModel(IConfirmationService confirmationService)
        {
            _confirmationService = confirmationService;
        }

        public string Result { get; set; } = "test";
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required] 
            [Display(Name = "badgeId")]
            public string badgeId { get; set; }
            
            [Required]
            [Display(Name = "roomId")]
            public int roomId { get; set; }
        }
        public void OnGet()
        {
            Input = new InputModel()
            {
                badgeId = string.Empty,
                roomId = 0
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var serviceResponse = await _confirmationService.IsClientAllowed(Input.badgeId, Input.roomId);
            Result = !serviceResponse.Success ? "Not allowed" : "Allowed";

            return Page();
        }
    }
}
