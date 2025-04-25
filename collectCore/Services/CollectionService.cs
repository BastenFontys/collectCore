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

        public async Task<List<Collection>> GetCollectionsByUserID(int userID)
        {
            return await _collectionRepo.GetCollectionsByUserID(userID);
        }

        public async Task<Collection> GetCollectionByID(int id)
        {
            return await _collectionRepo.GetCollectionByID(id);
        }

        public async Task<Collection> CreateCollection(int userID, string name)
        {
            return await _collectionRepo.CreateCollection(userID, name);
        }

        public void DeleteCollection(int id)
        {
            _collectionRepo.DeleteCollection(id);
        }
    }
}
