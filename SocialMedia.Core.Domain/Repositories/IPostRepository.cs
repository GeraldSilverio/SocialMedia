using SocialMedia.Core.Domain.Entities;

namespace SocialMedia.Core.Domain.Repositories;

public interface IPostRepository
{
    List<Post> GetPostByUsers(Guid id);
    void Add(Post post);
}