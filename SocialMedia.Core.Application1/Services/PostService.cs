using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;

namespace SocialMedia.Core.Application1.Services;

public class PostService(IPostRepository postRepository, IFriendService friendService,IUserRepository userRepository) : IPostService
{
    /// <summary>
    /// Obtiene las publicaciones de los amigos de un usuario dado su ID.
    /// </summary>
    /// <param name="id">ID del usuario.</param>
    /// <returns>Lista de objetos GetPostDto que representan las publicaciones de los amigos del usuario.</returns>
    /// <exception cref="ApplicationException">Lanzada cuando ocurre un error al recuperar las publicaciones.</exception>
    public Response<List<GetPostDto>> GetPostByUsers(Guid id)
    {
        try
        {
            var posts = new List<GetPostDto>();
            var friends = friendService.GetFriendByIdUser(id);

            foreach (var friend in friends)
            {
                var friendPosts = postRepository.GetPostByUsers(friend.Data.IdFriend).ToList();
                foreach (var post in friendPosts)
                {
                    posts.Add(new GetPostDto
                    {
                        IdUser = post.IdUser,
                        Id = post.Id,
                        Date = post.Date,
                        Text = post.Text,
                        UserName = userRepository.GetUserById(post.IdUser).UserName
                    });
                }
            }

            return new Response<List<GetPostDto>>(true, null, posts);
        }
        catch (Exception ex)
        {
            //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
            //errores en produccion muchos mas rapido.
            throw new ApplicationException($"Ocurrio un error al tratar de conseguir los post{ex.Message}", ex);
        }
    }

    /// <summary>
    /// Metodo para agregar un nuevo post a la lista de posts.
    /// </summary>
    /// <param name="post"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Response<PostDto> Add(PostDto post)
    {
        try
        {
            var model = new Post(Guid.NewGuid(), post.Text, post.IdUser, DateTime.Now);
            postRepository.Add(model);
            return new Response<PostDto>(true, null, post);
        }
        catch (Exception ex)
        {
            //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
            //errores en produccion muchos mas rapido.
            throw new ApplicationException($"Error al intentar agregar un post{ex.Message}", ex);
        }
    }
}