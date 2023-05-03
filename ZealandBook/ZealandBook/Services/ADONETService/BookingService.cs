using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class BookingService : IBookingService
    {
        public void CreateBooking(Booking booking)
        {
            SQLServiceBooking.CreateBooking(booking);
        }
    }
}
