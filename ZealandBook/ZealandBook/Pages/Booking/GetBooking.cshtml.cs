using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Booking;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook
{
    public class GetBookingModel : PageModel
    {
        [BindProperty]
        public Booking booking { get; set; } = new Booking();
        [BindProperty]
        public Room rooms { get; set; }
        public IEnumerable<Booking> bookings { get; set; }
        private IBookingService bookingService { get; set; }
        public GetBookingModel(IBookingService service)
        {
            this.bookingService = service;
        }
        
        public void OnGet()
        {
            bookings = SQLServiceBooking.GetAllBookings();
            foreach(Booking booking in bookings)
            {
                rooms = bookingService.GetRoomById(booking.Room_Id);
            }

        }
       
    }
}
