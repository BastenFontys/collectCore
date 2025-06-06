﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using collectCoreDAL.Interfaces;
using collectCoreDAL.DTO;
using collectCoreBLL.Mappers;
using collectCoreBLL.Services;

namespace colectCoreTest
{
    public class TestUserService
    {
        private readonly Mock<IUserRepo> _mockRepo;
        private readonly UserMapper _mapper;
        private readonly UserService _service;

        public TestUserService()
        {
            _mockRepo = new Mock<IUserRepo>();
            _mapper = new UserMapper();
            _service = new UserService(_mockRepo.Object, _mapper);
        }



        [Fact]
        public async Task GetUserProfileAsync_ValidId_ReturnsUser()
        {
            var dto = new UserDTO { UserID = 1, Username = "TestUser" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(dto);

            var result = await _service.GetUserProfileAsync(1);

            Assert.NotNull(result);
            Assert.Equal("TestUser", result.Username);
        }

        [Fact]
        public async Task GetUserProfileAsync_InvalidId_ThrowsArgumentException()
        {
            int invalidID = 0;

            var result = await Assert.ThrowsAsync<ArgumentException>(() => _service.GetUserProfileAsync(invalidID));

            Assert.Equal("User ID must be greater than zero. (Parameter 'id')", result.Message);
        }



        [Fact]
        public async Task GetByCredentialAsync_ValidCredentials_ReturnsUser()
        {
            var dto = new UserDTO { Email = "test@email.com", Password = "1234", Username = "Test" };
            _mockRepo.Setup(r => r.GetByCredentialsAsync("test@email.com", "1234")).ReturnsAsync(dto);

            var result = await _service.GetByCredentialAsync("test@email.com", "1234");

            Assert.NotNull(result);
            Assert.Equal("Test", result.Username);
        }

        [Fact]
        public async Task GetByCredentialAsync_InvalidEmail_ThrowsArgumentException()
        {
            string invalidEmail = "not-an-email";
            string password = "validpassword";

            var result = await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.GetByCredentialAsync(invalidEmail, password)
            );

            Assert.Equal("Invalid email format. (Parameter 'email')", result.Message);
        }



        [Fact]
        public async Task CreateUser_ValidInput_ReturnsCreatedUser()
        {
            var dto = new UserDTO { Username = "NewUser", Email = "new@email.com" };
            _mockRepo.Setup(r => r.CreateUser("NewUser", "new@email.com", "password", "Rachelsmolen", 1)).ReturnsAsync(dto);

            var result = await _service.CreateUser("NewUser", "new@email.com", "password", "Rachelsmolen", 1);

            Assert.NotNull(result);
            Assert.Equal("NewUser", result.Username);
        }

        [Fact]
        public async Task CreateUser_PasswordTooShort_ThrowsArgumentException()
        {
            string username = "User";
            string email = "user@example.com";
            string shortPassword = "123";

            var result = await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.CreateUser(username, email, shortPassword)
            );

            Assert.Equal("Password must be at least 6 characters. (Parameter 'password')", result.Message);
        }
    }
}
