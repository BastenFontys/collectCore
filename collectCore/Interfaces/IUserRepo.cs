using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByCredentialsAsync(string email, string password);

        Task<User> CreateUser(string username, string email, string password, string address_street = "", int address_number = 0);
    }
}
