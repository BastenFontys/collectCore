using collectCoreDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreDAL.Interfaces
{
    public interface IPostRepo
    {
        Task<List<PostDTO>> GetAllPostsByUserID(int userID);
    }
}
