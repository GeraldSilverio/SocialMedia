namespace SocialMedia.Core.Domain.Entities;

public class Post(Guid id, string text, Guid idUser, DateTime date)
{
    public Guid Id { get; private set; } = id;
    public string Text { get; private set; } = text;
    public Guid IdUser { get; private set; } = idUser;
    public DateTime Date { get; private set; } = date;
}