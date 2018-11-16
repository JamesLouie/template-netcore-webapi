using Microsoft.Extensions.DependencyInjection;
using template.Api.Settings;
using template.Application.Handlers;
using template.Application.Interfaces.External;
using template.Application.Providers;
using template.Persistence.Mongo.Repositories;
//using template.Persistence.Sql.Repositories;

namespace template.Api.Configurations
{
    public static class ApplicationConfiguration
    {
        public static void ConfigureApplication(this IServiceCollection services, AppSettings settings)
        {
            ConfigureInternal(services, settings);
            ConfigureExternal(services, settings);
        }

        private static void ConfigureInternal(IServiceCollection services, AppSettings settings)
        {
            services.AddTransient<ICustomerHandler, CustomerHandler>();
            services.AddTransient<IBillingInformationHandler, BillingInformationHandler>();
        }

        private static void ConfigureExternal(IServiceCollection services, AppSettings settings)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBillingInformationRepository, BillingInformationRepository>();
        }
    }
}
