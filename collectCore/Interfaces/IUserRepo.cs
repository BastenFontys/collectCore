using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByIdAsync(int id);
    }
}
