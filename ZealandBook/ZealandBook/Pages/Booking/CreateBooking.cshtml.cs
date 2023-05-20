using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Booking;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook
{
    public class CreateBookingModel : PageModel
    {
       

        [BindProperty]
        public Booking booking { get; set; } = new Booking();
      
        private IBookingService bookingService;
        public CreateBookingModel(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public void OnGet(int rid, int studentId, int teacherId)
        {
            if (int.TryParse(HttpContext.Session.GetString("LoggedInStudentId"), out  studentId))
            {
                booking.Student_Id = studentId;
            }
            if (int.TryParse(HttpContext.Session.GetString("LoggedInTeacherId"), out  teacherId))
            {
                booking.Teacher_Id = teacherId;
            }

            booking.Room_Id = rid;
        }
        public IActionResult OnPost(Booking booking, int bid, int rid, int roomId, int teacherId, int studentId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingService.CreateBooking(booking);
            SQLServiceRoom.UpdateRoomStatus(rid);
            return RedirectToPage("GetBooking");
            


        }
    }
}