using collectCore.Models;
using collectCore.Interfaces;
using collectCore.Repos;

namespace collectCore.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUserProfileAsync(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }
    }
}
