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
            Assert.IsNotNull(bookings, "Bookings should[TestMethod]\r\npublic void TestDeleteBooking_Success()\r\n{\r\n    // Arrange\r\n    List<Booking> bookings = _bookingServices.GetAllBookings();\r\n    int initialCount = bookings.Count;\r\n\r\n    // Select a booking to delete (assuming it exists)\r\n    Booking bookingToDelete = bookings.FirstOrDefault();\r\n\r\n    if (bookingToDelete == null)\r\n    {\r\n        Assert.Inconclusive(\"No booking found to delete.\");\r\n    }\r\n\r\n    int bookingId = bookingToDelete.BookingID;\r\n\r\n    // Act\r\n    _bookingServices.DeleteBooking(bookingId);\r\n\r\n    List<Booking> bookingsAfterDeletion = _bookingServices.GetAllBookings();\r\n    int finalCount = bookingsAfterDeletion.Count;\r\n\r\n    // Assert\r\n    Assert.IsTrue(finalCount < initialCount, $\"Booking with ID {bookingId} should be deleted\");\r\n}\r\nnt be null");
            Assert.IsTrue(bookings.Count > 0, "At least one booking exist");
        }
        
        
        [TestMethod]
        public void TestDeleteBooking_Succes()
        {
            // Arrange
            List<Booking> bookings = _bookingServices.GetAllBookings();
            int initialCount = bookings.Count;

            // Select a booking to delete 
            Booking bookingToDelete = bookings.FirstOrDefault();

            if (bookingToDelete == null)
            {
                Assert.Inconclusive("No booking found to delete.");
            }

            int bookingId = bookingToDelete.BookingID;

            // Act
            _bookingServices.DeleteBooking(bookingId);

            List<Booking> bookingsAfterDeletion = _bookingServices.GetAllBookings();
            int finalCount = bookingsAfterDeletion.Count;

            // Assert
            Assert.IsTrue(finalCount < initialCount, $"Booking with ID {bookingId} should be deleted");
        }
        
        
        [TestMethod]
        public void TestCreateBooking_Success()
        {
            // Arrange
            Booking bookingprop = new Booking
            {
                DateFrom = DateTime.Now.AddDays(1),
                DateTo = DateTime.Now.AddDays(2),
                Student_Id = 1,
                Teacher_Id = null,
                Room_Id = 1
            };

            // Act
            Booking booking = new Booking
            {
                DateFrom = bookingprop.DateFrom.AddDays(2),
                DateTo = bookingprop.DateTo.AddHours(2),
                Student_Id = bookingprop.Student_Id,
                Teacher_Id = bookingprop.Teacher_Id,
                Room_Id = bookingprop.Room_Id
            };

            // Assert
            Assert.IsNotNull(booking, "Should not be null");
            Assert.AreEqual(bookingprop.DateFrom.AddDays(2), booking.DateFrom, "DateFrom match the value");
            Assert.AreEqual(bookingprop.DateTo.AddHours(2), booking.DateTo, "DateTo match the value");
            Assert.AreEqual(bookingprop.Student_Id, booking.Student_Id, "Student_Id match  the value");
            Assert.AreEqual(bookingprop.Teacher_Id, booking.Teacher_Id, "Teacher_Id match the value");
            Assert.AreEqual(bookingprop.Room_Id, booking.Room_Id, "Room_Id match the value");
        }








    }
}
