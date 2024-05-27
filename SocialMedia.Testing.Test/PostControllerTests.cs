using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Application1.Services;
using SocialMedia.Infraestructure.Persistence.Repositories;
using SocialMedia.Presentation.WebApi.Controllers;


namespace SocialMedia.Testing.Test
{
    public class PostControllerTests
    {
        private readonly PostController _postController;
        private readonly IPostService _postService;
        private readonly IFriendService _friendService;
        private IUserService _userService;

        public PostControllerTests()
        {
            _postService = new PostService(new PostRepository(), new FriendService(new FriendRepository()), new UserRepository());
            _postController = new PostController(_postService);
            _friendService = new FriendService(new FriendRepository());
            _userService = new UserService(new UserRepository());
        }

        [Fact]
        public void CreatePost_ReturnTrue_CorrectRequest()
        {
            // Arrange
            var parameters = new PostDto
            {
                IdUser = Guid.NewGuid(),
                Text = "Hola, soy un text"
            };

            // Act
            var result = _postController.Add(parameters) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            var response = Assert.IsType<Response<PostDto>>(result.Value);
            Assert.True(response.Succeeded);
        }
        [Fact]
        public void GetPost_Return0_WithNoPostCreated()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var result = _postController.Get(id) as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
            var response = Assert.IsType<Response<List<GetPostDto>>>(result.Value);
            Assert.True(response.Succeeded);
            Assert.Empty(response.Data);
        }
        [Fact]
        public void GetPost_ReturnPost_WithPostCreated()
        {
            //Arrange 
            var user = _userService.GetByUserName("Ivan");
            var friends = new FriendsDto { IdUser = Guid.NewGuid(), IdFriend = user.Data.Id };
            var parameters = new PostDto { IdUser = user.Data.Id, Text = "Hello" };

            //Act
            _friendService.Add(friends);
            _postController.Add(parameters);
            var result = _postController.Get(friends.IdUser) as ObjectResult;

            //Assert 
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            var response = Assert.IsType<Response<List<GetPostDto>>>(result.Value);
            Assert.True(response.Succeeded);
            Assert.NotEmpty(response.Data);
        }
    }
}
