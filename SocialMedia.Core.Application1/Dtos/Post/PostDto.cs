using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialMedia.Core.Application1.Dtos.Post;

public class PostDto
{
    [Required(ErrorMessage ="El cuerpo del post no puede ser nulo")]
    public string? Text { get; set; }
    [Required(ErrorMessage = "El IdUsuario no puede ser nulo")]
    public Guid IdUser { get; set; }
}