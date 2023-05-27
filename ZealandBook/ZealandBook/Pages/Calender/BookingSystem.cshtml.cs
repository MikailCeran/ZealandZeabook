using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class BookingSystemModel : PageModel
    {

        [BindProperty]
        public Booking booking { get; set; } = new Booking();

        private IBookingService bookingService;
        public BookingSystemModel(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public IEnumerable<int> bookings { get; set; }

        public void OnGet(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            bookings = bookingService.GetAllAvailableRoomIds(specificDate, specificTimeFrom, specificTimeTo);

        }


        //public List<int> GetAllAvailableRoomIds(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo);



       
    }
}
