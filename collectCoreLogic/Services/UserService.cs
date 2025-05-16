using collectCoreBLL.Mappers;
using collectCoreBLL.Models;
using collectCoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;
        private UserMapper _userMapper;

        public UserService(IUserRepo userRepo, UserMapper userMapper)
        {
            _userRepo = userRepo;
            _userMapper = userMapper;
        }

        public async Task<User> GetUserProfileAsync(int id)
        {
            var dto = await _userRepo.GetByIdAsync(id);
            return _userMapper.ToModel(dto);
        }

        public async Task<User> GetByCredentialAsync(string email, string password)
        {
            var dto = await _userRepo.GetByCredentialsAsync(email, password);
            return _userMapper.ToModel(dto); 
        }

        public async Task<User> CreateUser(string username, string email, string password, string? adress_street = null, int adress_number = 0)
        {
            var dto = await _userRepo.CreateUser(username, email, password, adress_street, adress_number);
            return _userMapper.ToModel(dto);
        }
    }
}
