namespace SocialMedia.Core.Domain.Entities;

public class Friend(Guid id, Guid idUser, Guid idFriend)
{
    public Guid Id { get; set; } = id;
    public Guid IdUser { get; set; } = idUser;
    public Guid IdFriend { get; set; } = idFriend;
}