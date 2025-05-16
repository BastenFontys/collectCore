using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class collectionModel : PageModel
    {
        private readonly CollectionService _collectionService;
        
        public collectionModel(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [BindProperty]
        public List<Collection> Collections { get; set; }

        [BindProperty]
        public int collectionID { get; set; }


        public async Task<IActionResult> OnGet()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            int userid = int.Parse(cookie);

            var collections = await _collectionService.GetCollectionsByUserID(userid);
            if (collections == null)
            {
                return NotFound();
            }

            Collections = collections;
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

            _collectionService.DeleteCollection(collectionID);

            return RedirectToPage("/collection");
        }
    }
}
