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
        private readonly ITeacherService _teacherService;
        

        public MyBookingsModel(IBookingService bookingService, IStudentService studentService, ITeacherService teacherService)
        {
            _bookingService = bookingService;
            _studentService = studentService;
            _teacherService = teacherService;
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

            if (int.TryParse(HttpContext.Session.GetString("LoggedInTeacherId"), out int teacherId))
            {
                Teacher teacher = _teacherService.GetTeacherById(teacherId);
                Bookings = _bookingService.GetBookingsByTeacherId(teacherId);

            }
            return Page();
        }
        
    }
}

