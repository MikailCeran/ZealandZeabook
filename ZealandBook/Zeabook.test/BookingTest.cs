using Microsoft.VisualStudio.TestTools.UnitTesting;using ZealandBook.Models;
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
            Assert.IsNotNull(bookings, "Should not be null");
            Assert.IsTrue(bookings.Count > 1, "At least one booking exist");

            //Denne test sikrer, at der findes mindst én booking og at listen over bookinger ikke er tom.
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

            //Denne test sikrer, at en booking bliver slettet ved at sammenligne antallet af bookinger før og efter sletning.
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

            //Denne test sikrer, at en booking bliver oprettet med korrekte værdier, herunder datoer, studerende, lærer og lokale.
        }








    }
}
