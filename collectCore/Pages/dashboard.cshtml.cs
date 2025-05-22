using collectCoreBLL.Models;
using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class dashboardModel : PageModel
    {
        private readonly PriceTrendService _pricetrendService;
        private readonly CollectionService _collectionService;

        public dashboardModel(PriceTrendService pricetrendService, CollectionService collectionService)
        {
            _pricetrendService = pricetrendService;
            _collectionService = collectionService;
        }

        public List<float> Data { get; set; }
        public List<string> Labels { get; set; }

        [BindProperty]
        public int CollectionID { get; set; }

        public List<Collection> Collections { get; set; }


        public async Task<IActionResult> OnGet(int? collectionID, string range = "1M")
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


            if (collectionID.HasValue)
            {
                CollectionID = collectionID.Value;
            }
            else
            {
                CollectionID = Collections.First().CollectionID;
            }

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

            int userid = int.Parse(cookie);

            var collections = await _collectionService.GetCollectionsByUserID(userid);
            if (collections == null)
            {
                return NotFound();
            }

            Collections = collections;

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
