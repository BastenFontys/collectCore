using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collectCoreDAL.DTO;

namespace collectCoreDAL.Interfaces
{
    public interface IItemRepo
    {
        Task<List<ItemDTO>> GetItemsByCollectionID(int collectionID);

        Task<List<ItemDTO>> GetAllItems();
    }
}
