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

        public List <Room> rooms { get; set; }

        public void OnGet(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
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
        }

    }
}


