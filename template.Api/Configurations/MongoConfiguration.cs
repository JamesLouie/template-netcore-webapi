using Microsoft.Extensions.DependencyInjection;
using template.Api.Settings;
using template.Persistence.Mongo.Client;

namespace template.Api.Configurations
{
    public static class MongoConfiguration
    {
        public static void ConfigureMongo(this IServiceCollection services, AppSettings settings)
        {
            services.AddSingleton<MongoConnector>(new MongoConnector(settings.Mongo.ConnectionString, settings.Mongo.DatabaseName));
        }
    }
}
