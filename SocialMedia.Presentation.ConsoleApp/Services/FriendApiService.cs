using SocialMedia.Core.Application1.Dtos.Friend;
using SocialMedia.Core.Application1.Response;
using System.Net.Http.Json;

namespace SocialMedia.Presentation.ConsoleApp.Services
{
    /// <summary>
    /// Servicio para las peticiones a la API a los endpoints de Amigos
    /// </summary>
    public class FriendApiService
    {
        private readonly HttpClient _httpClient;

        public FriendApiService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7128/api/v1/");
        }
        /// <summary>
        /// Se encarga de enviar un request via POST a la api, para agregar los amigos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<FriendsDto>> AddFriend(FriendsDto request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}Friend", request);
                return await response.Content.ReadFromJsonAsync<Response<FriendsDto>>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
