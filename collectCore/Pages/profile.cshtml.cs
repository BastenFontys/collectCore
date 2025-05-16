using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class profileModel : PageModel
    {
        private readonly UserService _userService;

        public profileModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }


        public async Task<IActionResult> OnGet()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            int id = int.Parse(cookie);

            var user = await _userService.GetUserProfileAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            User = user;
            return Page();
        }
    }
}
