using collectCoreDAL.DTO;
using collectCoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Mappers
{
    public class ItemMapper
    {
        public Item ToModel(ItemDTO dto)
        {
            return new Item
            {
                ItemID = dto.ItemID,
                Name = dto.Name,
                ItemValue = dto.ItemValue,
                CollectionItemID = dto.CollectionItemID
            };
        }

        public ItemDTO ToDTO(Item model)
        {
            return new ItemDTO
            {
                ItemID = model.ItemID,
                Name = model.Name,
                ItemValue = model.ItemValue,
                CollectionItemID = model.CollectionItemID
            };
        }
    }
}
