using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Application1.Services;
using SocialMedia.Core.Domain.Repositories;
using SocialMedia.Infraestructure.Persistence.Repositories;
using SocialMedia.Presentation.WebApi.Controllers;
namespace SocialMedia.Testing.Test
{
    public class FriendControllerTests
    {
        private readonly FriendController _friendController;
        private readonly FriendService _friendService;
        private readonly IFriendRepository _friendRepository;

        public FriendControllerTests()
        {
            _friendRepository = new FriendRepository();
            _friendService = new FriendService(_friendRepository);
            _friendController = new FriendController(_friendService);
        }

        [Fact]
        public void AddFriend_ReturnsCreated_WithCorrectRequest()
        {
            // Arrange
            var parameters = new FriendsDto
            {
                IdUser = Guid.NewGuid(),
                IdFriend = Guid.NewGuid()
            };

            // Act
            var result = _friendController.AddFriend(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            var response = Assert.IsType<Response<FriendsDto>>(result.Value);
            Assert.True(response.Succeeded);
            Assert.Equal(parameters.IdUser, response.Data.IdUser);
            Assert.Equal(parameters.IdFriend, response.Data.IdFriend);
        }

        
        [Fact]
        public void AddFriend_ReturnsBadRequest_WithSameIdUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var parameters = new FriendsDto
            {
                IdUser = userId,
                IdFriend = userId
            };

            // Act
            var result = _friendController.AddFriend(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            var response = Assert.IsType<Response<FriendsDto>>(result.Value);
            Assert.False(response.Succeeded);
        }

        [Fact]
        public void AddFriend_ReturnsFalse_WhenAddingExistingFriends()
        {
            // Arrange
            var parameters = new FriendsDto
            {
                IdUser = Guid.NewGuid(),
                IdFriend = Guid.NewGuid()
            };

            // Act
            var result = _friendController.AddFriend(parameters) as ObjectResult;
            var result2 = _friendController.AddFriend(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result2.StatusCode);
            var response = Assert.IsType<Response<FriendsDto>>(result2.Value);
            Assert.False(response.Succeeded);
        }

    }
}
