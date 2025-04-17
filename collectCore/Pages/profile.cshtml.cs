using collectCore.Models;
using collectCore.Services;
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


        public async Task<IActionResult> OnGet(int id)
        {
            if (Request.Cookies["cookie"] == null)
            {
                // Not logged in? Send to login
                return RedirectToPage("/Login");
            }

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
