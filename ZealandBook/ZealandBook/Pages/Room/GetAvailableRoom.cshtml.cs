using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Room;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook
{
    public class GetAvailableRoomModel : PageModel
    {
        [BindProperty]
        Room room { get; set; } = new Room();
        public IEnumerable<Room> rooms { get; set; }
        private IRoomService roomService { get; set; }

        public GetAvailableRoomModel(IRoomService service)
        {
            this.roomService = service;
        }

        public void OnGet(int rid)
        {
            rooms = SQLServiceRoom.GetAllAvailableRooms();

        }
        public void OnPost()
        {

        }
    }
}
