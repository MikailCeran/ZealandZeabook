using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using ZealandBook.Models;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class BookingSystemModel : PageModel
    {
        [BindProperty]
        public Booking booking { get; set; } = new Booking();
        public Room room { get; set; } = new Room();

        private IBookingService bookingService;
        public BookingSystemModel(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public IEnumerable<int> bookings { get; set; }
        public List<Room> rooms { get; set; }
        public List<DateTime> AvailableDates { get; set; }
        public List<string> AvailableTimes { get; set; }

        public void OnGet(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            AvailableDates = GetAvailableDates();  // Set the available dates
            AvailableTimes = GetAvailableTimes();  // Set the available times

            // Check if the search parameters are provided
            if (specificDate != default(DateTime) && specificTimeFrom != default(TimeSpan) && specificTimeTo != default(TimeSpan))
            {
                // Perform the search
                bookings = bookingService.GetAllAvailableRoomIds(specificDate, specificTimeFrom, specificTimeTo);

                // Retrieve the room information
                rooms = new List<Room>();
                foreach (var roomId in bookings)
                {
                    var room = bookingService.GetRoomById(roomId);
                    if (room != null)
                        rooms.Add(room);
                }
            }
            else
            {
                // Set default values or leave the lists empty
                bookings = new List<int>();
                rooms = new List<Room>();
            }

            booking.Date = specificDate;
            booking.DateFrom = specificTimeFrom;
            booking.DateTo = specificTimeTo;
            bookingService.DeleteBookingsBeforeToday();
        }

        public List<DateTime> GetAvailableDates()
        {
            var availableDates = new List<DateTime>();

            // Define the date range
            DateTime startDate = DateTime.Today; // Example: Today's date
            DateTime endDate = DateTime.Today.AddDays(7); // Example: 7 days from today

            // Generate available dates within the specified range
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                availableDates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }

            return availableDates;
        }

        public List<string> GetAvailableTimes()
        {
            var availableTimes = new List<string>();

            // Define your time range and interval
            TimeSpan startTime = new TimeSpan(8, 0, 0); // Example: 8:00 AM
            TimeSpan endTime = new TimeSpan(18, 0, 0); // Example: 6:00 PM
            TimeSpan interval = new TimeSpan(0, 30, 0); // Example: 30 minutes

            // Generate available times within the specified range
            TimeSpan currentTime = startTime;
            while (currentTime < endTime)
            {
                availableTimes.Add(currentTime.ToString("hh\\:mm"));
                currentTime = currentTime.Add(interval);
            }

            return availableTimes;
        }
    }
}
