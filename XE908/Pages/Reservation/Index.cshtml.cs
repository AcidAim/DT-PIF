using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Models;
using XE908.Services.RoomService;

namespace XE908.Pages.Reservation
{
    public class IndexModel : PageModel
    {
        private readonly IRoomService _roomService;

        public IndexModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public List<ConferenceRoom> ConferenceRooms { get; set; }
        public async Task OnGetAsync()
        {
            ConferenceRooms = (await _roomService.GetAllConferenceRoomsAsync()).Data;
        }
    }
}
