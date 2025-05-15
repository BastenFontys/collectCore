using collectCoreDAL.DTO;
using collectCoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Mappers
{
    public class CollectionMapper
    {
        public Collection ToModel(CollectionDTO dto)
        {
            return new Collection
            {
                CollectionID = dto.CollectionID,
                Name = dto.Name
            };
        }

        public CollectionDTO ToDTO(Collection model)
        {
            return new CollectionDTO
            {
                CollectionID = model.CollectionID,
                Name = model.Name
            };
        }
    }
}
