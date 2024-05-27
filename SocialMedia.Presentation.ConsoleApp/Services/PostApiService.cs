using SocialMedia.Core.Application1.Dtos.Post;
using SocialMedia.Core.Application1.Dtos.User;
using SocialMedia.Core.Application1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Presentation.ConsoleApp.Services
{
    /// <summary>
    /// Servicio para las peticiones a la API a los endpoints de Posts
    /// </summary>
    public class PostApiService
    {
        private readonly HttpClient _httpClient;

        public PostApiService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7128/api/v1/");
        }
        /// <summary>
        /// Agregar un nuevo post mediante una peticion POST a la API.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<PostDto>> Post(PostDto request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}Post", request);
                return await response.Content.ReadFromJsonAsync<Response<PostDto>>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        /// <summary>
        /// Obtener todos los post de los amigos del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<List<GetPostDto>>> GetPostById(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}Post/ByFriendId/{id}");
                var e = await response.Content.ReadAsStringAsync();
                return await response.Content.ReadFromJsonAsync<Response<List<GetPostDto>>>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
