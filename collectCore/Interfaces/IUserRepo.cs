using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByCredentialsAsync(string email, string password);

        Task<User> CreateUser(string username, string email, string password, string? adress_street, int? adress_number);
    }
}
