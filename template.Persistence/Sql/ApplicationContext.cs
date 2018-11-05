using Microsoft.EntityFrameworkCore;
using template.Persistence.Sql.Mappings;
using template.Persistence.Sql.Utilities;

namespace template.Persistence.Sql
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<AddressMap> Addresses { get; set; }
        internal DbSet<BillingInformationMap> BillingInformations { get; set; }
        internal DbSet<CustomerMap> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
