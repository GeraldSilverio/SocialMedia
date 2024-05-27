using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Presentation.WebApi.Controllers
{
    /// <summary>
    /// Controlador base de la api
    /// </summary>
    //Instalando algunas librerias, se puede documentar la API y tambien versionar dicha API
    //No lo implemente, para cumplir con el mandanto de no instalar librerias externas.
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    
    public abstract class BaseController : ControllerBase
    {

    }
}
