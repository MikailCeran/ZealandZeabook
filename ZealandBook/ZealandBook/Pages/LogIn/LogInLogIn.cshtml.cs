using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using ZealandBook.Models;
using ZealandBook.Pages.LogIn;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class LogInLogInModel : PageModel
    {
        private readonly IStudentService studentService;

        public LogInLogInModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        [Required]
 
        [Display(Name = "Email")]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
           
            // Attempt to retrieve the student from the database
            Student = studentService.GetStudentByEmailAndPassword(Email, Password);

            if (Student == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return Page();
            }

            HttpContext.Session.SetString("LoggedInStudentId", Student.StudentId.ToString());

            // Redirect to the home page
            return RedirectToPage("/Index");
        }
    }
}
