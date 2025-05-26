using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages.Details
{
    public class Show_CollectionModel : PageModel
    {
        private readonly CollectionService _collectionService;
        private readonly ItemService _itemService;

        public Show_CollectionModel(CollectionService collectionService, ItemService itemService)
        {
            _collectionService = collectionService;
            _itemService = itemService;
        }

        [BindProperty]
        public Collection Collection { get; set; }

        [BindProperty]
        public List<Item> Items { get; set; }

        [BindProperty]
        public int CollectionItemID { get; set; }


        public async Task<IActionResult> OnGet(int collectionid)
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            var collection = await _collectionService.GetCollectionByID(collectionid);
            if (collection == null)
            {
                return NotFound();
            }

            Collection = collection;

            var items = await _itemService.GetItemsByCollectionID(collectionid);
            if (items == null)
            {
                return Page();
            }

            Items = items;
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            _collectionService.DeleteItemFromCollection(CollectionItemID);

            return RedirectToPage("/collection");
        }
    }
}
