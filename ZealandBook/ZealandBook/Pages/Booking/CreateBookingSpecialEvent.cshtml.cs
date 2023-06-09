using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Booking;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook
{
    public class CreateBookingModelSpecialEvent : PageModel
    {


        [BindProperty]
        public Booking booking { get; set; } = new Booking();

        private IBookingService bookingService;
        public CreateBookingModelSpecialEvent(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public void OnGet(int rid)
        {
            if (int.TryParse(HttpContext.Session.GetString("LoggedInStudentId"), out int studentId))
            {
                booking.Student_Id = studentId;
            }

            if (int.TryParse(HttpContext.Session.GetString("LoggedInTeacherId"), out int teacherId))
            {
                booking.Teacher_Id = teacherId;
            }


            booking.Room_Id = rid;
        }
        public IActionResult OnPost(Booking booking, int bid, int rid, int roomId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingService.CreateBooking(booking);
            SQLServiceRoom.UpdateRoomStatus(rid);
            return RedirectToPage("MyBookings");



        }
    }
}