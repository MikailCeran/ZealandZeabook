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
        public List<Booking> GetBookingsByTeacherId(int id)
        {
            return SQLServiceBooking.GetBookingsByTeacherId(id);
        }

        public void DeleteBooking(int id)
        {
            SQLServiceBooking.DeleteBooking(id);
        }

        public Booking GetBookingById(int id)
        {
            return SQLServiceBooking.GetBookingById(id);
        }

        public List<int> GetAllAvailableRoomIds(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            return SQLServiceBooking.GetAllAvailableRoomIds(specificDate, specificTimeFrom, specificTimeTo);
        }

    }
}
