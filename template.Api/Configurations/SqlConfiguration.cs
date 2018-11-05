using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using template.Api.Settings;
using template.Persistence.Sql;

namespace template.Api.Configurations
{
    public static class SqlConfiguration
    {
        public static void ConfigureSql(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(settings.SqlServer.ConnectionString));
        }
    }
}
