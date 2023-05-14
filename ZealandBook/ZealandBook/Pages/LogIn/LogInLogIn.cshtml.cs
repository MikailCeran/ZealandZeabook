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

        [BindProperty]
        public Student student { get; set; } = new Student();
        public IEnumerable<Student> students { get; set; }
        private IStudentService studentService { get; set; }
        public LogInLogInModel(IStudentService service)
        {
            this.studentService = service;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Query the database for a student with the given username and password
            Student student = studentService.GetStudentByEmailAndPassword(Username, Password);

            // If no student was found, return an error
            if (student == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return Page();
            }

            // If a student was found, log them in
            // You can store their information in a cookie or session
            // Or you can redirect them to a new page
            return RedirectToPage("Index");
        }




    }


}
