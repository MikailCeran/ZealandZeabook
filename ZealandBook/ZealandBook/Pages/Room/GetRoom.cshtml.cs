using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;
using ZealandBook.Pages.Room;
using ZealandBook.Models;

namespace ZealandBook
{
    public class GetRoomModel : PageModel
    {
        [BindProperty]
        public Room room{ get; set; } = new Room();
        public IEnumerable<Room> rooms { get; set; }
        private IRoomService roomService { get; set; }
        public GetRoomModel(IRoomService service)
        {
            this.roomService = service;
        }

        public void OnGet(int rid)
        {
           rooms= SQLServiceRoom.GetAllRooms();
        }
        public void OnPost()
        {

        }
    }
}

