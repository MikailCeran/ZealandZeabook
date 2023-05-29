using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
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

        

        //public void OnGet(DateTime date, TimeSpan specificDateFrom, TimeSpan specificDateTo, int roomId, int rid)
        //{
        //    if (int.TryParse(HttpContext.Session.GetString("LoggedInStudentId"), out int studentId))
        //    {
        //        booking.Student_Id = studentId;
        //    }

        //    if (int.TryParse(HttpContext.Session.GetString("LoggedInTeacherId"), out int teacherId))
        //    {
        //        booking.Teacher_Id = teacherId;
        //    }


        //    booking.Room_Id = rid;
        //    booking.Date = date.Date;
        //    booking.DateFrom = specificDateFrom;
        //    booking.DateTo = specificDateTo;

        //}

        public IActionResult OnPost(Booking booking, DateTime date, TimeSpan specificDateFrom, TimeSpan specificDateTo, int roomId)
        {


            if (int.TryParse(HttpContext.Session.GetString("LoggedInStudentId"), out int studentId))
            {
                booking.Student_Id = studentId;
            }

            if (int.TryParse(HttpContext.Session.GetString("LoggedInTeacherId"), out int teacherId))
            {
                booking.Teacher_Id = teacherId;
            }

            SQLServiceRoom.UpdateRoomStatus(roomId);

            booking.Room_Id = roomId;
            booking.Date = date.Date;
            booking.DateFrom = specificDateFrom;
            booking.DateTo = specificDateTo;



            if (!bookingService.HasExistingBookingTeacher(teacherId) && !bookingService.HasExistingBookingStudent(studentId))
            {
                bookingService.CreateBooking(booking);
                return RedirectToPage("/Booking/MyBookings");
            }
            else
            {
                ViewData["Message"] = "Vent til din eksisterende booking er overstået";
                return Page();
            }






        }


    }
}