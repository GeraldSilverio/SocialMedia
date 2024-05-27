using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Response;

namespace SocialMedia.Core.Application1.Interfaces.Services;

public interface IPostService
{
    Response<List<GetPostDto>> GetPostByUsers(Guid id);
    Response<PostDto> Add(PostDto post);
}