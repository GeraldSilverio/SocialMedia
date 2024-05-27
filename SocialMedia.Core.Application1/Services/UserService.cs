using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Interfaces.Services;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Application1.Services
{
    /// <summary>
    /// Servicio de usuarios
    /// </summary>
    /// <param name="userRepository"></param>
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public Response<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public Response<List<UserDto>> GetAll()
        {
            try
            {
                var users = userRepository.GetAll()
                    .Select(x => new UserDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        LastName = x.LastName,
                        UserName = x.UserName,
                    }).ToList();

                return new Response<List<UserDto>>
                {
                    Data = users,
                    Succeeded = true,
                    Message = null
                };
            }
            catch (Exception ex)
            {
                //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
                //errores en produccion muchos mas rapido.
                throw new ApplicationException($"Ocurrio un error al tratar de conseguir los usuarios{ex.Message}", ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public Response<UserDto> GetByUserName(string userName)
        {
            try
            {
                var user = userRepository.GetByUserName(userName);
                if (user != null)
                {

                    var response = new Response<UserDto>()
                    {
                        Data = new()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            LastName = user.LastName,
                            UserName = user.UserName,
                        },
                        Succeeded = true,
                        Message = null
                    };
                    return response;
                }
                return new Response<UserDto>(false, $"No se encontro ningun usuario con{userName}", null);
            }
            catch (Exception ex)
            {
                //Aqui se pueden implementar un log para capturar los errores no deseados y asi saber el StakcTrace de los 
                //errores en produccion muchos mas rapido.
                throw new ApplicationException($"Ocurrio un error al tratar de conseguir los usuarios{ex.Message}", ex);
            }
        }
    }
}
