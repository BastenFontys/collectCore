using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class dashboardModel : PageModel
    {
        private readonly PriceTrendService _pricetrendService;

        public dashboardModel(PriceTrendService pricetrendService)
        {
            _pricetrendService = pricetrendService;
        }

        public List<float> Data { get; set; }
        public List<string> Labels { get; set; }

        [BindProperty]
        public int CollectionID { get; set; }

        public List<Collection> Collections { get; set; }


        public async Task<IActionResult> OnGet(int collectionID = 1, string range = "1M")
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            CollectionID = collectionID;

            Collections = new List<Collection>
            {
                new Collection { CollectionID = 1, Name = "Collection 1" },
                new Collection { CollectionID = 2, Name = "Collection 2" },
                new Collection { CollectionID = 3, Name = "Collection 3" }
            };

            var data = await _pricetrendService.GetPriceTrend(CollectionID, range);
            if (data == null)
            {
                return NotFound();
            }

            Labels = _pricetrendService.GetLabels(range);
            Data = data;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            Collections = new List<Collection>
            {
                new Collection { CollectionID = 1, Name = "Collection 1" },
                new Collection { CollectionID = 2, Name = "Collection 2" },
                new Collection { CollectionID = 3, Name = "Collection 3" }
            };

            var data = await _pricetrendService.GetPriceTrend(CollectionID, "1M");
            if (data == null)
            {
                return NotFound();
            }

            Labels = _pricetrendService.GetLabels("1M");
            Data = data;
            return Page();
        }
    }
}
