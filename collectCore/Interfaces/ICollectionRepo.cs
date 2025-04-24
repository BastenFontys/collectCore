using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface ICollectionRepo
    {
        Task<List<Collection>> GetCollectionsByUserID(int id);
    }
}
