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


        public async Task<IActionResult> OnGet(string range = "1M")
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            var data = await _pricetrendService.GetPriceTrend(3);
            if (data == null)
            {
                return NotFound();
            }

            Labels = _pricetrendService.GetLabels(range);
            Data = data;
            return Page();
        }
    }
}
