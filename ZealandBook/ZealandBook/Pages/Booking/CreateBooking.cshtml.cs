using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Booking;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook
{
    public class CreateBookingModel : PageModel
    {
        [BindProperty]
        public Booking booking { get; set; } = new Booking();
        public void OnGet(int bid)
        {
        }
        private IBookingService bookingService;
        public CreateBookingModel(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        public IActionResult OnPost(Booking booking, int bid, int rid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingService.CreateBooking(booking);
            SQLServiceRoom.UpdateRoomStatus(rid);
            return RedirectToPage("GetBooking");
        }
    }
}