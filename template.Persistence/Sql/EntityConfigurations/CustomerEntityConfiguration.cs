using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using template.Persistence.Sql.Mappings;

namespace template.Persistence.Sql.EntityConfigurations
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerMap>
    {
        public void Configure(EntityTypeBuilder<CustomerMap> builder)
        {
            builder.ToTable("Customer").HasKey(x => x.CustomerId);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Email);
            builder.Property(x => x.DateRegistered);
            builder.Property(x => x.IsActive);
        }
    }
}
