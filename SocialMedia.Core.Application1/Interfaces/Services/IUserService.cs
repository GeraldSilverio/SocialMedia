using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Response;
using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Application1.Interfaces.Services
{
    public interface IUserService
    {
        Response<List<UserDto>> GetAll();
        Response<UserDto> GetByUserName(string userName);
        Response<User> AddUser(User user);
    }
}
