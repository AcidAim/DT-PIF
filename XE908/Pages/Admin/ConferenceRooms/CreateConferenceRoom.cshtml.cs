using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XE908.Dtos.ConferenceRoomDto;
using XE908.Services.ControllerService;
using XE908.Services.RoomService;
using Controller = XE908.Models.Controller;

namespace XE908.Pages.Admin.ConferenceRooms
{
    [Authorize(Roles = "Administrator")]
    public class CreateConferenceRoomModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IControllerService _controllerService;
        private readonly NavigationManager _navigationManager;
        
        public CreateConferenceRoomModel(IRoomService roomService, IControllerService controllerService, NavigationManager navigationManager)
        {
            _roomService = roomService;
            _controllerService = controllerService;
            _navigationManager = navigationManager;
        }
        public AddConferenceRoomDto? NewConferenceRoom { get; set; }
        public List<Controller> AvailableControllers { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required] public string RoomNumber { get; set; }
            [Required] public string RoomDescription { get; set; }
            [Required] public int RoomCapacity { get; set; }
            [Required] public string RoomControllerHostName { get; set; }
            
        }
        public async Task OnGetAsync()
        {
            AvailableControllers = (await _controllerService.GetAllAvailableControllersAsync()).Data!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Input.RoomNumber != null && Input.RoomDescription != null 
                                         && Input.RoomCapacity != null && Input.RoomControllerHostName != null)
            {
                try
                {
                    NewConferenceRoom = new AddConferenceRoomDto();
                    NewConferenceRoom.RoomNumber = Input.RoomNumber; 
                    NewConferenceRoom.RoomDescription = Input.RoomDescription; 
                    NewConferenceRoom.Capacity = Input.RoomCapacity; 
                    NewConferenceRoom.ControllerId = Input.RoomControllerHostName; 
                    NewConferenceRoom.Controller =
                                        (await _controllerService.GetControllerByHostNameAsync(Input.RoomControllerHostName)).Data!; 
                    await _roomService.CreateConferenceRoomAsync(NewConferenceRoom);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            await OnGetAsync();
            return Page();
        }
    }
}
