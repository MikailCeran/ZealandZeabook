//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using ZealandBook.Models;
//using ZealandBook.Services.Interface;
//using ZealandBook.Services;

//namespace ZealandBook
//{
//    private readonly IStudentService _studentService;
//    private readonly UserManager<Student> _userManager;

//    public MyBookingsModel(IStudentService studentService, UserManager<Student> userManager)
//    {
//        _studentService = studentService;
//        _userManager = userManager;
//    }

//    public List<Booking> Bookings { get; set; }

//    public async Task<IActionResult> OnGetAsync()
//    {
//        // Get the current user
//        var user = await _userManager.GetUserAsync(User);

//        // Get the bookings for the current user
//        Bookings = _studentService.GetBookingsForStudent(user.Id).ToList();

//        return Page();
//    }
//}
