using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class signupModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Request.Cookies["auth_user"] != null)
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }
    }
}
