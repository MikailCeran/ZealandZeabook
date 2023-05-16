using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ZealandBook.Services.Interface;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;

namespace ZealandBook
{
    public class MyBookingsModel : PageModel
    {
        
        private readonly IBookingService _bookingService;
        private readonly IStudentService _studentService;
        

        public MyBookingsModel(IBookingService bookingService, IStudentService studentService)
        {
            _bookingService = bookingService;
            _studentService = studentService;
        }

        
        [BindProperty]
        public IEnumerable<Booking> Bookings { get; set; }

        public IActionResult OnGet()
        {
            if (int.TryParse(HttpContext.Session.GetString("LoggedInStudentId"), out int studentId))
            {
                Student student = _studentService.GetStudentById(studentId);
                Bookings = _bookingService.GetBookingsByStudentId(studentId);

            }

            return Page();

        
        }
    }
}

