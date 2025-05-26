using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ItemService _itemService;

        public SearchModel(ItemService itemService)
        {
            _itemService = itemService;
        }


        [BindProperty(SupportsGet = true)]
        public string Query { get; set; }

        public List<Item> Items { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var allItems = await _itemService.GetAllItems();

            if (!string.IsNullOrWhiteSpace(Query))
            {
                Items = allItems
                    .Where(item => item.Name.Contains(Query, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Items = allItems;
            }
            return Page();
        }
    }
}
