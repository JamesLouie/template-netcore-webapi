using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace template.Persistence.Sql.Utilities
{
    internal static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var implementedConfigTypes = typeof(ApplicationContext).Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract
                    && !t.IsGenericTypeDefinition
                    && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
                        i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }
        }
    }
}
