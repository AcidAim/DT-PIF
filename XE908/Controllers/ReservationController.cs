using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XE908.Dtos.ReservationDto;
using XE908.Services.ReservationService;

namespace XE908.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(AddReservationDto reservationDto)
        {
            var serviceResponse = await _reservationService.CreateReservationAsync(reservationDto);
            if (!serviceResponse.Success)
            {
                return BadRequest();
            }

            return Created("Success", serviceResponse);
        }
    }
}
