using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;
using ZealandBook.Services.Interface;
using ZealandBook;

namespace ZealandBook
{
    public class CreateRoomModel : PageModel
    {
        [BindProperty]
        public Room room { get; set; } = new Room();
        public void OnGet(int rid)
        {
        }
        private IRoomService roomService { get; set; }
        public CreateRoomModel (IRoomService roomService)
        {
            this.roomService = roomService;
        }
        public IActionResult OnPost(Room room, int rid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            roomService.CreateRoom(room);
            return RedirectToPage("");
        }
    }
}
