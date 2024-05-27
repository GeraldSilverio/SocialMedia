using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Presentation.ConsoleApp.Services;
using SocialMedia.Presentation.ConsoleApp.UI;
using System.Net.Http;

namespace SocialMedia.Presentation.ConsoleApp;
class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .AddScoped<UserApiService>()
            .AddScoped<PostApiService>()
            .AddScoped<FriendApiService>()
            .AddScoped<MenuService>()
            .BuildServiceProvider();

        var menuService = serviceProvider.GetService<MenuService>();

        while (true)
        {
            Console.WriteLine("Hola, que deseas realizar hoy:");
            var text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text)) break;
            await menuService.ExecuteCommandAsync(text);
        }
    }
}