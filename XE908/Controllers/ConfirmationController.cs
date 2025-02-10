using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XE908.Services.ConfirmationService;

namespace XE908.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationController : ControllerBase
    {
        private readonly IConfirmationService _confirmation;

        public ConfirmationController(IConfirmationService confirmation)
        {
            _confirmation = confirmation;
        }

        [HttpGet]
        public async Task<IActionResult> checkRequest(string badgeId, int roomId)
        {
            var serviceResponse = await _confirmation.IsClientAllowed(badgeId, roomId);
            if (serviceResponse.Success)
            {
                return Content("{\"allowed\": \"true\"}", "application/json");
            }
            //return Content("{\"allowed\": \"false\"}");
            return NotFound();
        }
    }
    
    
}
