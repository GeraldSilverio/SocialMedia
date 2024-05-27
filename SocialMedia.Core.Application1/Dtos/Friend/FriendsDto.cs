using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Application1.Dtos.Friend
{
    public class FriendsDto
    {
        [Required(ErrorMessage = "IdUsuario es requerido")]
        public Guid IdUser { get; set; }
        [Required(ErrorMessage = "IdFriend es requerido")]
        public Guid IdFriend { get; set; }
    }
}
