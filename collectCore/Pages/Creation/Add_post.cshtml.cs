using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages.Creation
{
    public class Add_postModel : PageModel
    {
        private readonly UserService _userService;
        private readonly PostService _postService;

        public Add_postModel(UserService userService, PostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }



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

        public async Task<IActionResult> OnPost()
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

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await ImageFile.CopyToAsync(memoryStream);

                byte[] imageBytes = memoryStream.ToArray();
                string mimeType = ImageFile.ContentType;

                Post.ImageData = imageBytes;
                Post.MimeType = mimeType;

                _postService.CreatePost(User.UserID, Post);
            }

            return RedirectToPage("/profile");
        }
    }
}
