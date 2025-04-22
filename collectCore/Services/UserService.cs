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

        public async Task<User> GetByCredentialAsync(string email, string password)
        {
            return await _userRepo.GetByCredentialsAsync(email, password);
        }

        public async Task<User> CreateUser(string username, string email, string password, string? adress_street = null, int? adress_number = null)
        {
            return await _userRepo.CreateUser(username, email, password, adress_street, adress_number);
        }
    }
}
