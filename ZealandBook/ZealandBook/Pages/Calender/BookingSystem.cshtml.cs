using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZealandBook.Pages.Calender
{
    public class BookingSystemModel : PageModel
    {
        // Properties
        public List<int> AvailableRoomIds { get; set; }

        // GET request handler
        public void OnGet()
        {
            // Initialize the available room IDs as an empty list
            AvailableRoomIds = new List<int>();
        }

        // POST request handler
        public IActionResult OnPost(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            // Call the GetAllAvailableRoomIds method to retrieve the available room IDs
            AvailableRoomIds = GetAllAvailableRoomIds(specificDate, specificTimeFrom, specificTimeTo);

            // Return the same page with the updated results
            return Page();
        }

        // Function to get all available room IDs
        public List<int> GetAllAvailableRoomIds(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            // Implement your logic to retrieve the available room IDs here
            // You can use the existing SQL query or any other method you prefer

            List<int> roomIds = new List<int>();

            // Add your code here to retrieve the available room IDs

            return roomIds;
        }
    }
}
