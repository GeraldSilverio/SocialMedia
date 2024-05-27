
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SocialMedia.Presentation.WebApi.Extensions
{
  
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialMedia");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }

      
    }
}
