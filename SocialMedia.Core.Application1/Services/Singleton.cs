using SocialMedia.Core.Domain.Entities;

namespace SocialMedia.Core.Application1.Services;

/// <summary>
/// Clase para tener las 3 listas que usuare en el proyecto, implementando
/// el patron singleton, para solo tener una instancia de dichas listas
/// asi evito que siempre me cree una lista nueva y no se pierda en el heap.
/// </summary>
public abstract class Singleton
{
    private Singleton()
    {
    }

    private static List<User> _users;
    private static List<Post> _posts;
    private static List<Friend> _friends;

    /// <summary>
    /// Metodo estatico, que valida si la lista de users es nula, si lo es, me crea una instancia de la misma,
    /// en caso de que no, me devuelve la instancia ya creada anteriormente.
    /// </summary>
    /// <returns>Lista de usuarios</returns>
    public static List<User> GetUsers()
    {
        return _users != null
            ? _users
            : _users =
            [
                new User(Guid.NewGuid(), "Alfonso", "Rodriguez", "Alfonso"),
                new User(Guid.NewGuid(), "Ivan", "Serrata", "Ivan"),
                new User(Guid.NewGuid(), "Alicia", "Silverio", "Alicia")
            ];
    }

    /// <summary>
    /// Metodo estatico, que valida si la lista de posts es nula, si lo es, me crea una instancia de la misma,
    /// en caso de que no, me devuelve la instancia ya creada anteriormente.
    /// </summary>
    /// <returns>Lista de posts</returns>
    public static List<Post> GetPost()
    {
        if (_posts == null)
        {
            _posts = new List<Post>();
        }
        return _posts;
    }

    /// <summary>
    /// Metodo estatico, que valida si la lista de Friends es nula, si lo es, me crea una instancia de la misma,
    /// en caso de que no, me devuelve la instancia ya creada anteriormente.
    /// </summary>
    /// <returns>Lista de Friends</returns>
    public static List<Friend> GetFriends()
    {
        if (_friends == null)
        {
            _friends = new List<Friend>();
        }
        return _friends;
    }
}