using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace SocialMedia.Presentation.ConsoleApp.Services
{
    /// <summary>
    /// Servicio para las peticiones a la API a los endpoints de Users
    /// </summary>
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7128/api/v1/");
        }
        /// <summary>
        /// Obtiene los datos del usuario mediante el userName.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<UserDto>> GetUserByUserName(string userName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}User/{userName}");
                return await response.Content.ReadFromJsonAsync<Response<UserDto>>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }


    }
}
