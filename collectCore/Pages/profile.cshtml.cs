using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using collectCore.Models;
using collectCore.Repos;

namespace collectCore.Pages
{
    public class profileModel : PageModel
    {
        private readonly UserRepo _repo;

        public profileModel(UserRepo repo)
        {
            _repo = repo;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _repo.GetAll();
        }
    }
}
