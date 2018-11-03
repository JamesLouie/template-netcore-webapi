using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace template.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "My Api",
                    Version = "v1"
                });
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api");
            });
        }
    }
}
