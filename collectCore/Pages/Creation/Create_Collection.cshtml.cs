using collectCoreBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages.Creation
{
    public class Create_CollectionModel : PageModel
    {
        private readonly CollectionService _collectionService;

        public Create_CollectionModel(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }
        
        [BindProperty]
        public string Name { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            int userid = int.Parse(cookie);

            var NewCollection = await _collectionService.CreateCollection(userid, Name);
            if (NewCollection == null)
            {
                return NotFound();
            }

            return RedirectToPage("/collection");
        }
    }
}
