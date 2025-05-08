using collectCore.Models;
using collectCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages.Creation
{
    public class Add_cardModel : PageModel
    {
        private readonly CollectionService _collectionService;
        private readonly ItemService _itemService;

        public Add_cardModel(CollectionService collectionService, ItemService itemService)
        {
            _collectionService = collectionService;
            _itemService = itemService;
        }

        [BindProperty]
        public List<Item> Items { get; set; }


        public async Task<IActionResult> OnGet()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            var items = await _itemService.GetAllItems();
            if (items == null)
            {
                return NotFound();
            }

            Items = items;
            return Page();
        }
    }
}
