using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.Student;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class CreateTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher teacher { get; set; } = new Teacher();
        public void OnGet(int bid)
        {
        }
        private ITeacherService teacherService;
        public CreateTeacherModel(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public IActionResult OnPost(Student student, int bid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            teacherService.CreateTeacher(teacher);
            return RedirectToPage("");
        }
    }
}