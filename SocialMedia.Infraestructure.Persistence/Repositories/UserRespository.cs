using SocialMedia.Core.Application1.Services;
using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.Repositories;

namespace SocialMedia.Infraestructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            return Singleton.GetUsers();
        }

        public User GetByUserName(string userName)
        {
            var users = Singleton.GetUsers();
            var user = users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            return user;
        }

        public void AddUser(User user)
        {
            var users = Singleton.GetUsers();
            users.Add(user);
        }

        public User GetUserById(Guid id)
        {
            try
            {
                return Singleton.GetUsers().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}