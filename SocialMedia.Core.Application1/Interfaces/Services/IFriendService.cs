using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Response;

namespace SocialMedia.Core.Application1.Interfaces.Services
{
    public interface IFriendService
    {
        List<Response<FriendsDto>> GetFriendByIdUser(Guid idUser);
        Response<FriendsDto> Add(FriendsDto friend);
    }
}
