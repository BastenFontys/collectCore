using collectCoreBLL.Mappers;
using collectCoreBLL.Models;
using collectCoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public async Task<User> GetUserProfileAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.", nameof(id));
            }
            var dto = await _userRepo.GetByIdAsync(id);
            return _userMapper.ToModel(dto);
        }

        public async Task<User> GetByCredentialAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.", nameof(email));
            }

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password is required.", nameof(password));
            }
                
            var dto = await _userRepo.GetByCredentialsAsync(email, password);
            return _userMapper.ToModel(dto); 
        }

        public async Task<User> CreateUser(string username, string email, string password, string? adress_street = null, int adress_number = 0)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username is required.", nameof(username));
            }
                
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.", nameof(email));
            }
                
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }
               
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters.", nameof(password));
            }
                
            var dto = await _userRepo.CreateUser(username, email, password, adress_street, adress_number);
            return _userMapper.ToModel(dto);
        }
    }
}
