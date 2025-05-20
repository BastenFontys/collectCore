using collectCoreBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectCore.Pages
{
    public class dashboardModel : PageModel
    {
        private readonly PriceTrendService _pricetrendService;

        public profileModel(UserService userService)
        {
            _userService = userService;
        }





        public List<float> Data { get; set; }






        public async Task<IActionResult> OnGet()
        {
            var cookie = Request.Cookies["auth_user"];
            if (cookie == null)
            {
                return RedirectToPage("/Login");
            }

            var data = await 
        }
    }
}
