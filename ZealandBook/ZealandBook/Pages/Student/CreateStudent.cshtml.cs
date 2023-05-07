using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Student;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student student { get; set; } = new Student();
        public void OnGet(int bid)
        {
        }
        private IStudentService studentService;
        public CreateStudentModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public IActionResult OnPost(Student student, int sid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            studentService.CreateStudent(student);
            return RedirectToPage("");
        }
    }
}