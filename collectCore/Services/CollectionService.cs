using collectCore.Interfaces;
using collectCore.Models;
using System.Reflection.Metadata.Ecma335;

namespace collectCore.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepo _collectionRepo;

        public CollectionService(ICollectionRepo collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        public async Task<List<Collection>> GetCollectionsByUserID(int id)
        {
            return await _collectionRepo.GetCollectionsByUserID(id);
        }
    }
}
