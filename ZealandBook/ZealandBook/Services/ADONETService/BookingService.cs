using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class BookingService : IBookingService
    {
        public  List<Booking> GetAllBookings()
        {
            return SQLServiceBooking.GetAllBookings();
        }
        public void CreateBooking(Booking booking)
        {
            SQLServiceBooking.CreateBooking(booking);
        }

        public List<Booking> GetBookingsByStudentId(int student)
        {
            return SQLServiceBooking.GetBookingsByStudentId(student);
        }

    }
}
