using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;

namespace SocialMedia.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    /// <summary>
    /// Endpoint que devuelve todos los usuarios del sistema
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        var user = userService.GetAll();
        return user.Data.Count <= 0 ? StatusCode(StatusCodes.Status204NoContent) : StatusCode(StatusCodes.Status200OK, user);
    }
    /// <summary>
    /// Endpoint que devuelve el usuario buscandolo por el userName
    /// </summary>
    /// <param name="userName">Nombre de usuario</param>
    /// <returns></returns>
    [HttpGet("{userName}")]
    public IActionResult GetByUserName(string userName)
    {
        var user = userService.GetByUserName(userName);
        return user.Succeeded ? Ok(user) : StatusCode(StatusCodes.Status204NoContent,user);
    }
}