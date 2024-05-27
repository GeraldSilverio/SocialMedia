using SocialMedia.Core.Domain.Entities;

namespace SocialMedia.Core.Domain.Repositories;

public interface IFriendRepository
{
    List<Friend> GetAllByUserId(Guid id);
    void Add(Friend friend);
    bool ValidateAreFriend(Guid idUser, Guid idFriend);
}