using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using template.Api.Configurations;
using template.Api.Filters;
using template.Api.Middleware;
using template.Api.Settings;

namespace template.Api
{
    public class Startup
    {
        public AppSettings AppSettings { get; }

        public Startup(IConfiguration configuration)
        {
            AppSettings = configuration.Get<AppSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(opt =>
                {
                    opt.Filters.Add(new ValidateModelAttribute());
                })
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.ConfigureSql(AppSettings);
            services.ConfigureMongo(AppSettings);
            services.ConfigureApplication(AppSettings);
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureSwagger();
            app.UseMiddleware<TenantInterceptor>();
            app.UseMvc();
        }
    }
}
