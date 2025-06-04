using System;
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
            // Arrange
            var dto = new UserDTO { UserID = 1, Username = "TestUser" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(dto);

            // Act
            var result = await _service.GetUserProfileAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestUser", result.Username);
        }
    }
}
