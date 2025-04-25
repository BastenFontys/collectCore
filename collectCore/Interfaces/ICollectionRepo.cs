using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface ICollectionRepo
    {
        Task<List<Collection>> GetCollectionsByUserID(int userID);

        Task<Collection> GetCollectionByID(int id);

        Task<Collection> CreateCollection(int userID, string name);
    }
}
