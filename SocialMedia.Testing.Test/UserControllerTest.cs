using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Application1.Services;
using SocialMedia.Infraestructure.Persistence.Repositories;
using SocialMedia.Presentation.WebApi.Controllers;

namespace SocialMedia.Testing.Test
{
    public class UserControllerTest
    {
        private readonly IUserService _userService;
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _userService = new UserService(new UserRepository());
            _userController = new UserController(_userService);
        }

        [Fact]
        public void GetUserByUserName_ReturnsTrue_WhenUserNameIsCorrect()
        {
            // Arrange
            var userName = "Ivan";


            // Act
            var result = _userController.GetByUserName(userName) as ObjectResult;
            var response = Assert.IsType<Response<UserDto>>(result.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.True(response.Succeeded);
            Assert.Null(response.Message);
            Assert.NotNull(response.Data);
            Assert.Equal(userName, response.Data.UserName);
        }
        [Fact]
        public void GetAllUser_ReturnsTrue_WhenUsersExist()
        {
            // Act
            var result = _userController.Get() as ObjectResult;
            var response = Assert.IsType<Response<List<UserDto>>>(result.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.True(response.Succeeded);
            Assert.Null(response.Message);
            Assert.NotNull(response.Data);
        }
        [Fact]
        public void GetUserByUserName_ReturnsfALSE_WhenUserNameIsInCorrect()
        {
            // Arrange
            var userName = "Test1";


            // Act
            var result = _userController.GetByUserName(userName) as ObjectResult;
            var response = Assert.IsType<Response<UserDto>>(result.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
            Assert.False(response.Succeeded);
            Assert.NotNull(response.Message);
            Assert.Null(response.Data);
        }
        [Fact]
        public void GetUserByUserName_ReturnsBadRequest_WhenUserNameIsEmpty()
        {
            // Arrange
            var userName = string.Empty;

            // Act
            var result = _userController.GetByUserName(userName) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
            var response = Assert.IsType<Response<UserDto>>(result.Value);
            Assert.False(response.Succeeded);
            Assert.Null(response.Data);
        }
    }
}
