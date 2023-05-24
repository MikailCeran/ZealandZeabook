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
        private readonly ITeacherService teacherService;

        public LogInLogInModel(IStudentService studentService, ITeacherService teacherService)
        {
            this.studentService = studentService;
            this.teacherService = teacherService;
        }



        [BindProperty]
        public Student Student { get; set; }
        [BindProperty]
        public Teacher Teacher{ get; set; }

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
            // Attempt to retrieve the student and teacher from the database
            Student = studentService.GetStudentByEmailAndPassword(Email, Password);
            Teacher = teacherService.GetTeacherByEmailAndPassword(Email, Password);

            if (Student != null)
            {
                HttpContext.Session.SetString("LoggedInStudentId", Student.StudentId.ToString());
                HttpContext.Session.SetString("LoggedInStudentName", Student.StudentName.ToString());

                // Redirect to the home page
                return RedirectToPage("/Index");
            }
            else if (Teacher != null)
            {

                HttpContext.Session.SetString("LoggedInTeacherId", Teacher.TeacherID.ToString());
                HttpContext.Session.SetString("TeacherAdmin", Teacher.Admin.ToString().ToLower());
                HttpContext.Session.SetString("LoggedInTeacherName", Teacher.TeacherName.ToString());
                

                // Redirect to the home page
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return Page();
            }


           

        }

    }
}
