using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collectCoreDAL.Interfaces;
using collectCoreBLL.Models;
using collectCoreBLL.Mappers;

namespace collectCoreBLL.Services
{
    public class CollectionService
    {
        private readonly ICollectionRepo _collectionRepo;
        private CollectionMapper _collectionMapper;

        public CollectionService(ICollectionRepo collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        public async Task<List<Collection>> GetCollectionsByUserID(int userID)
        {
            var dto = await _collectionRepo.GetCollectionsByUserID(userID);
            return _collectionMapper.ToModel(dto);
        }

        public async Task<Collection> GetCollectionByID(int id)
        {
            var dto = await _collectionRepo.GetCollectionByID(id);
            return _collectionMapper.ToModel(dto);
        }

        public async Task<Collection> CreateCollection(int userID, string name)
        {
            var dto = await _collectionRepo.CreateCollection(userID, name);
            return _collectionMapper.ToModel(dto);
        }

        public void DeleteCollection(int id)
        {
            _collectionRepo.DeleteCollection(id);
        }

        public void AddItemToCollection(int id, int itemid)
        {
            _collectionRepo.AddItemToCollection(id, itemid);
        }

        public void DeleteItemFromCollection(int id, int itemid)
        {
            _collectionRepo.DeleteItemFromCollection(id, itemid);
        }
    }
}
