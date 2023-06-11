using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Services.Interface;

namespace ZealandBook.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public DeleteModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public ZealandBook.Models.Booking Booking { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = _bookingService.GetBookingById(id.Value);

            if (Booking == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bookingService.DeleteBooking(id.Value);

            return RedirectToPage("/Booking/GetBooking");
        }
    }

}
