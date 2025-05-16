using collectCoreBLL.Models;
using collectCoreDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Mappers
{
    public class UserMapper
    {
        public User ToModel(UserDTO dto)
        {
            return new User
            {
                UserID = dto.UserID,
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                AdressStreet = dto.AdressStreet,
                AdressNumber = dto.AdressNumber,
                Biography = dto.Biography
            };
        }

        public UserDTO ToDTO(User model)
        {
            return new UserDTO
            {
                UserID = model.UserID,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                AdressStreet = model.AdressStreet,
                AdressNumber = model.AdressNumber,
                Biography = model.Biography
            };
        }
    }
}
