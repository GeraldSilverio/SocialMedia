using SocialMedia.Core.Domain.Entities;

namespace SocialMedia.Core.Domain.Repositories;

/// <summary>
/// Interfaz del respotirio de los usuarios.
/// </summary>
public interface IUserRepository
{
    List<User> GetAll();
    User GetByUserName(string userName);

    User GetUserById(Guid id);
    void AddUser(User user);
}