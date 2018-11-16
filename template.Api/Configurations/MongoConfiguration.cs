using Microsoft.Extensions.DependencyInjection;
using template.Api.Settings;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Configurations;

namespace template.Api.Configurations
{
    public static class MongoConfiguration
    {
        public static void ConfigureMongo(this IServiceCollection services, AppSettings settings)
        {
            // Settings
            services.AddSingleton<MongoConfig>(settings.Mongo);

            // Connection
            services.AddSingleton<MongoConnector>();
        }
    }
}
