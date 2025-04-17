using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public string Cookievalue { get; set; }



        private CookieOptions cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(1), // Short for testing; increase for production
            HttpOnly = true,
            Secure = true     
        };

        public IActionResult OnGet()
        {
            if (Request.Cookies["auth_user"] != null)
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Response.Cookies.Append("auth_user", Cookievalue, cookieOptions);

            return RedirectToPage("/Profile");
        }
    }
}
