namespace SocialMedia.Core.Domain.Entities;

/// <summary>
/// Clase POCO que representa un usuario.
/// </summary>
public class User(Guid id, string name, string lastName, string userName)
{
    /// <summary>
    /// Id del usuario
    /// </summary>
    public Guid Id { get; private set; } = id;

    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// Apellido del usuario
    /// </summary>
    public string LastName { get; private set; } = lastName;

    /// <summary>
    /// Nombre de usuario del usuario.
    /// </summary>
    public string UserName { get; private set; } = userName;
}