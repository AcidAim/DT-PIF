using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XE908.Pages.Admin.ConferenceRooms
{
    [Authorize(Roles = "Administrator")]
    public class ModifyConferenceRoomModel : PageModel
    {
        public int ConferenceRoomId { get; set; }
        public void OnGet(string conferenceRoomId)
        {
            ConferenceRoomId = int.Parse(conferenceRoomId);
        }
    }
}
