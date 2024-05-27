using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace SocialMedia.Presentation.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SocialMedia",
                    Description = "API creado con fines de prueba tecnica, implementado buenas practicas",
                    Contact = new OpenApiContact
                    {
                        Name = "Gerald Silverio",
                        Email = "es.geraldsilverio@gmail.com"

                    }
                });


            });
        }

        
    }

}

