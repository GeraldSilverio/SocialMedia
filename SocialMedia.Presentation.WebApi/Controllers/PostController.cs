using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Interfaces.Services;

namespace SocialMedia.Presentation.WebApi.Controllers;

/// <summary>
/// Controlador para los posts
/// </summary>
/// <param name="postService"></param>
//Instalando algunas librerias, se puede documentar la API y tambien versionar dicha API
//No lo implemente, para cumplir con el mandanto de no instalar librerias externas.
[ApiController]
[Route("api/v1/[controller]")]
public class PostController(IPostService postService) : BaseController
{
    /// <summary>
    /// Obtener todos los posts de los amigos que sigues.
    /// </summary>
    /// <param name="idUser">Id del usuario principal que desea ver los posts de sus amigos</param>
    /// <returns></returns>
    [HttpGet("ByFriendId/{idUser}")]
    public IActionResult Get(Guid idUser)
    {
        try
        {
            var posts = postService.GetPostByUsers(idUser);
            return posts.Data.Count == 0 ? StatusCode(StatusCodes.Status204NoContent,posts) : StatusCode(StatusCodes.Status200OK, posts);
        }
        catch (Exception ex)
        {
            //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
            //errores en produccion muchos mas rapido.
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    /// <summary>
    /// Endpoint para crear un nuevo post a la lista de posts.
    /// </summary>
    /// <param name="post">Request</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Add([FromBody] PostDto post)
    {
        try
        {
            var response = postService.Add(post);
            return response.Succeeded ? StatusCode(StatusCodes.Status201Created, response) : StatusCode(StatusCodes.Status400BadRequest, response);
        }
        catch (Exception ex)
        {
            //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
            //errores en produccion muchos mas rapido.
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}