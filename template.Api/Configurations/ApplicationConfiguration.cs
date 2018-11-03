﻿using Microsoft.Extensions.DependencyInjection;
using template.Api.Settings;
using template.Application.Handlers;
using template.Application.Interfaces.External;
using template.Application.Providers;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Repositories;

namespace template.Api.Configurations
{
    public static class ApplicationConfiguration
    {
        public static void ConfigureApplication(this IServiceCollection services, AppSettings settings)
        {
            ConfigureInternal(services, settings);
            ConfigureInternal(services, settings);
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

            services.AddSingleton<MongoConnector>(new MongoConnector(settings.Database.ConnectionString, settings.Database.DatabaseName));
        }
    }
}