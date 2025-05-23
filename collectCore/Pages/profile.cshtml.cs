using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class profileModel : PageModel
    {
        private readonly UserService _userService;
        private readonly PostService _postService;

        public profileModel(UserService userService, PostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public List<Post> Posts { get; set; }


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

            var posts = await _postService.GetAllPostsByUserID(id);
            if (posts == null)
            {
                return NotFound();
            }

            Posts = posts;

            return Page();
        }
    }
}
