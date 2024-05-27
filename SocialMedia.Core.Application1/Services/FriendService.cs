using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;
using System.Reflection;

namespace SocialMedia.Core.Application1.Services
{
    public class FriendService(IFriendRepository friendRepository) : IFriendService
    {

        /// <summary>
        /// Metodo para agregar un nuevo amigo
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        public Response<FriendsDto> Add(FriendsDto friend)
        {
            try
            {
                var validate = ValidateFriend(friend);
                if (!validate.Succeeded)
                {
                    return validate;
                }
                var model = new Friend(Guid.NewGuid(), friend.IdUser, friend.IdFriend);
                friendRepository.Add(model);
                return validate;
            }
            catch (Exception ex)
            {
                //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
                //errores en produccion muchos mas rapido.

                throw new ApplicationException($"Error al intentar agregar un amigo{ex.Message}", ex);
            }

        }


        /// <summary>
        /// Obtiene una lista de amigos de un usuario dado su ID.
        /// </summary>
        /// <param name="idUser">ID del usuario.</param>
        /// <returns>Lista de objetos Response<FriendsDto> que representan los amigos del usuario.</returns>
        public List<Response<FriendsDto>> GetFriendByIdUser(Guid idUser)
        {
            try
            {
                return friendRepository.GetAllByUserId(idUser).Select(x => new Response<FriendsDto>
                {
                    Data = new FriendsDto
                    {
                        IdFriend = x.IdFriend,
                        IdUser = x.IdUser,
                    },
                    Succeeded = true,
                    Message = null
                }).ToList();
            }
            catch (Exception ex)
            {
                //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
                //errores en produccion muchos mas rapido.
                throw new ApplicationException($"Ocurrio un error al intentar conseguir los amigos del usuario{ex.Message}", ex);
            }
        }
        /// <summary>
        /// Metodo para validar los diferentes casos que pueden ocurrir al momento de agregar un amigo
        /// </summary>
        /// <param name="friend">Dto que viene desde la API</param>
        /// <returns>Objeto Response FriendsDto</returns>
        private Response<FriendsDto> ValidateFriend(FriendsDto friend)
        {
            try
            {
                if (string.Equals(friend.IdUser, friend.IdFriend))
                {
                    return new Response<FriendsDto>(false, "Error, no puedes agregarte tu mismo como amigo", friend);
                }
                if (friendRepository.ValidateAreFriend(friend.IdUser, friend.IdFriend))
                {
                    return new Response<FriendsDto>(false, "Error, ya son amigos", friend);
                }

                return new Response<FriendsDto>(true, null, friend);
            }
            catch (Exception ex)
            {
                //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
                //errores en produccion muchos mas rapido.
                throw new ApplicationException($"Error al intentar validar el request{ex.Message}", ex);
            }
        }
    }
}
