using SocialMedia.Core.Application1.Services;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;

namespace SocialMedia.Infraestructure.Persistence.Repositories;

/// <summary>
/// Simulando un patron repositorio, tratando esto
/// como si fuera mi abstraccion para acceder a datos.
/// </summary>
public class PostRepository : IPostRepository
{
    /// <summary>
    /// Metodo que busca los post del usuario que corresponda con el ID
    /// que recibe de parametro.
    /// </summary>
    /// <param name="id"> Id del usuario</param>
    /// <returns>Posts del usuario mediante su ID</returns>
    /// <exception cref="Exception"></exception>
    public List<Post> GetPostByUsers(Guid id)
    {
        try
        {
            return Singleton.GetPost().Where(x => x.IdUser == id).ToList();
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error al intentar obtener los posts{ex.Message}", ex);
        }
    }

    /// <summary>
    /// Metodo para agregar un post a la lista.
    /// </summary>
    /// <param name="post">Post que viene metiante el servicio</param>
    /// <exception cref="ApplicationException"></exception>
    public void Add(Post post)
    {
        try
        {
           Singleton.GetPost().Add(post);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error al intentar agregar un post {ex.Message}", ex);
        }
    }

}