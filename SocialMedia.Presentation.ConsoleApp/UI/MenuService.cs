using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Emuns;
using SocialMedia.Presentation.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Presentation.ConsoleApp.UI
{
    public class MenuService
    {
        private readonly UserApiService _userService;
        private readonly PostApiService _postService;
        private readonly FriendApiService _friendService;

        public MenuService(UserApiService userService, PostApiService postService, FriendApiService friendService)
        {
            _userService = userService;
            _postService = postService;
            _friendService = friendService;
        }
        /// <summary>
        /// Ejecuta los comandos dependiendo cual sea el que el usario escriba por consola.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task ExecuteCommandAsync(string command)
        {
            var parts = command.Split(' ', 3);

            var actionString = parts[0].ToLower();
            var userPart = parts[1];

            if (!Enum.TryParse<Commands>(actionString, true, out var action))
            {
                Console.WriteLine("Comando invalido.");
                return;
            }

            switch (action)
            {
                case Commands.post:
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Comando invalido, por favor use este: post @user mensaje");
                        return;
                    }
                    await CreateNewPost(userPart, parts[2]);
                    break;

                case Commands.follow:
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Comando invalido, por favor use este: follow @user @friend");
                        return;
                    }
                    await AddFriend(userPart, parts[2]);
                    break;

                case Commands.wall:
                    Console.WriteLine($"> dashboard {userPart}");
                    await ReadWall(userPart);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
        /// <summary>
        /// Crea un nuevo post en la lista de publicaciones
        /// </summary>
        /// <param name="userPart">Nombre del usuario</param>
        /// <param name="message">Cuerpo del comentario</param>
        /// <returns></returns>
        private async Task CreateNewPost(string userPart, string message)
        {
            var user = await GetUser(userPart);
            if (user == null) return;

            var post = await _postService.Post(new PostDto
            {
                IdUser = user.Id,
                Text = message,
            });

            if (!post.Succeeded)
            {
                Console.WriteLine($"Error: {post.Message}");
                return;
            }

            Console.WriteLine($"Usuario: {userPart} Mensaje: {post.Data.Text}");
        }
        /// <summary>
        /// Agrega una amigo mediante una peticion POST
        /// </summary>
        /// <param name="userPart">Nombre del usuario</param>
        /// <param name="friendPart">Nombre del amigo</param>
        /// <returns></returns>
        private async Task AddFriend(string userPart, string friendPart)
        {
            var userA = await GetUser(userPart);
            var friend = await GetUser(friendPart);
            if (userA == null || friend == null) return;

            var request = await _friendService.AddFriend(new FriendsDto
            {
                IdFriend = friend.Id,
                IdUser = userA.Id
            });

            if (!request.Succeeded)
            {
                Console.WriteLine($"Error: {request.Message}");
                return;
            }

            Console.WriteLine($"Ahora {userA.UserName} y {friend.UserName} se siguen");
        }
        /// <summary>
        /// Obtiene mediante una peticion Get las publicaciones de los amigos del usuario que lo llama
        /// </summary>
        /// <param name="userPart">Nombre del usuario</param>
        /// <returns></returns>
        private async Task ReadWall(string userPart)
        {
            var user = await GetUser(userPart);
            if (user == null) return;

            var walls = await _postService.GetPostById(user.Id);
            if (walls.Data.Count > 0)
            {
                foreach (var post in walls.Data)
                {
                    Console.WriteLine($"{post.Text} @{post.UserName} {post.Date.Hour}:{post.Date.Minute} {post.Date.ToString("tt")}");
                }
            }
            else
            {
                Console.WriteLine("Tus amigos no han publicado nada");
            }
        }
        /// <summary>
        /// Obtiene mediante una peticion GET a la api el usuario que corresponda con el username.
        /// </summary>
        /// <param name="userPart"></param>
        /// <returns></returns>
        private async Task<UserDto> GetUser(string userPart)
        {
            var userResponse = await _userService.GetUserByUserName(userPart.Replace("@", ""));
            if (!userResponse.Succeeded)
            {
                Console.WriteLine($"Error: {userResponse.Message}");
                return null;
            }
            return userResponse.Data;
        }
    }
}


