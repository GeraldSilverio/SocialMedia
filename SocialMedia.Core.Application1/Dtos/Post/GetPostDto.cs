namespace SocialMedia.Core.Application1.Dtos.Post;

public class GetPostDto
{
    public Guid Id { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
    public Guid IdUser { get; set; }
    public string UserName { get; set; }

}