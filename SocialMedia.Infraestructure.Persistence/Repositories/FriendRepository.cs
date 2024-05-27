using SocialMedia.Core.Application1.Services;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;

namespace SocialMedia.Infraestructure.Persistence.Repositories;

public class FriendRepository : IFriendRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<Friend> GetAllByUserId(Guid id)
    {
        try
        {

            return Singleton.GetFriends().Where(x => x.IdUser == id).ToList();
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Ocurrio al encontrar a los amigos{ex.Message}", ex);

        }
    }

    /// <summary>
    /// Metodo para agregar un amigo a la lista.
    /// </summary>
    /// <param name="friend"></param>
    public void Add(Friend friend)
    {
        try
        {
            Singleton.GetFriends().Add(friend);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Ocurrio un error al intetar agregar un amigo{ex.Message}", ex);

        }
    }

    /// <summary>
    /// Metodo para validar si 2 usuarios ya son amigos, si ya lo son, devuelve true, sino false.
    /// </summary>
    /// <param name="idUser">Id del usuario que desea agregar un amigo</param>
    /// <param name="idFriend">Id del usuario al cual quieren agregar como amigo</param>
    /// <returns> True o false dependiendo si son amigos o no</returns>
    /// <exception cref="ApplicationException"></exception>
    public bool ValidateAreFriend(Guid idUser, Guid idFriend)
    {
        try
        {
            return Singleton.GetFriends().Any(x => x.IdUser == idUser && x.IdFriend == idFriend);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Ocurrio un error al validar si son amigos{ex.Message}", ex);
        }
    }
}