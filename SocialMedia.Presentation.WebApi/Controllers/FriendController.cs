using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Interfaces.Services;

namespace SocialMedia.Presentation.WebApi.Controllers
{

    //Instalando algunas librerias, se puede documentar la API y tambien versionar dicha API
    //No lo implemente, para cumplir con el mandanto de no instalar librerias externas.

    /// <summary>
    /// Controlador para Friends
    /// </summary>
    /// <param name="friendService"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FriendController(IFriendService friendService) : BaseController
    {
        /// <summary>
        /// Endpoint para agregar un amigo.
        /// </summary>
        /// <param name="friendsDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddFriend([FromBody] FriendsDto friendsDto)
        {
            try
            {
                if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, friendsDto);

                var response = friendService.Add(friendsDto);

                return response.Succeeded ? StatusCode(StatusCodes.Status201Created,response) : StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
