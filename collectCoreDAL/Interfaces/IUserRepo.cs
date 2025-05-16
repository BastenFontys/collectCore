using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collectCoreDAL.DTO;

namespace collectCoreDAL.Interfaces
{
    public interface IUserRepo
    {
        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> GetByCredentialsAsync(string email, string password);

        Task<UserDTO> CreateUser(string username, string email, string password, string? adress_street, int adress_number);
    }
}
