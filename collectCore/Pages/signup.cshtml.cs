using collectCore.Models;
using collectCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string AdressStreet { get; set; }

        [BindProperty]
        public string AdressNumber { get; set; }

        public User User { get; set; }

        private CookieOptions cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(2), // Short for testing; increase for production
            HttpOnly = true,
            Secure = true
        };

        private readonly UserService _userService;

        public signupModel(UserService userService)
        {
            _userService = userService;
        }


        public IActionResult OnGet()
        {
            if (Request.Cookies["auth_user"] != null)
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userService.CreateUser(Username, Email, Password);
            if (user == null)
            {
                return NotFound();
            }

            User = user;
            string Cookievalue = User.UserID.ToString();

            Response.Cookies.Append("auth_user", Cookievalue, cookieOptions);

            return RedirectToPage("/Profile");
        }
    }
}
