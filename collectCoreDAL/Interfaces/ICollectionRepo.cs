using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collectCoreDAL.DTO;

namespace collectCoreDAL.Interfaces
{
    public interface ICollectionRepo
    {
        Task<List<CollectionDTO>> GetCollectionsByUserID(int userID);

        Task<CollectionDTO> GetCollectionByID(int id);

        Task<CollectionDTO> CreateCollection(int userID, string name);

        void DeleteCollection(int id);

        void AddItemToCollection(int id, int itemid);

        void DeleteItemFromCollection(int id, int itemid);
    }
}
