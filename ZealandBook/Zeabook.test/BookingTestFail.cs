using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;
using System.Collections.Generic;
using ZealandBook.Services.SQLService;

namespace Zeabook.test
{
    [TestClass]
    public class BookingTest
    {
        private SQLServiceBooking _bookingService;
        private BookingService _bookingServices;

        [TestInitialize]
        public void TestInitialize()
        {
            _bookingService = new SQLServiceBooking();
            _bookingServices = new BookingService();
        }

        [TestMethod]
        public void TestGetAllBookings()
        {
            // Act
            List<Booking> bookings = _bookingServices.GetAllBookings();

            // Assert
            Assert.IsNotNull(bookings, "Bookings shouldnt be null");
            Assert.IsTrue(bookings.Count > 0, "At least one booking exist");
        }


    }
}
