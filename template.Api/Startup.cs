using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using template.Application.Handlers;
using template.Application.Interfaces.External;
using template.Application.Providers;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Repositories;

namespace template.Api
{
    public class Startup
    {
        public AppSettings AppSettings { get; }

        public Startup(IConfiguration configuration)
        {
            AppSettings = configuration.Get<AppSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ICustomerHandler, CustomerHandler>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<MongoConnector>(new MongoConnector(AppSettings.Database.ConnectionString, AppSettings.Database.DatabaseName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
