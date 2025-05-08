using collectCore.Interfaces;
using collectCore.Models;
using collectCore.Repos;

namespace collectCore.Services
{
    public class ItemService
    {
        private readonly IItemRepo _itemRepo;

        public ItemService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemRepo.GetAllItems();
        }

        public async Task<List<Item>> GetItemsByCollectionID(int collectionID)
        {
            return await _itemRepo.GetItemsByCollectionID(collectionID);
        }

    }
}
