using collectCore.Models;

namespace collectCore.Interfaces
{
    public interface IItemRepo
    {
        Task<List<Item>> GetItemsByCollectionID(int collectionID);
    }
}
