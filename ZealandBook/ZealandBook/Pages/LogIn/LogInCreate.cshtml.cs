using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandBook.Models;
using ZealandBook.Pages.LogIn;
using ZealandBook.Services.Interface;

namespace ZealandBook
{
    public class LogInCreateModel : PageModel
    {
        [BindProperty]
        public LogIn user { get; set; } = new LogIn();
      
        private ILogInService logInService;
        public LogInCreateModel(ILogInService logInService)
        {
            this.logInService = logInService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(LogIn user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            logInService.CreateUser(user);
            return RedirectToPage("Index");
            


        }
    
    }
}
