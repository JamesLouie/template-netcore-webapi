using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using template.Persistence.Sql.Mappings;

namespace template.Persistence.Sql.EntityConfigurations
{
    internal class AddressEntityConfiguration : IEntityTypeConfiguration<AddressMap>
    {
        public void Configure(EntityTypeBuilder<AddressMap> builder)
        {
            builder.ToTable("Address").HasKey(x => x.AddressId);
            builder.Property(x => x.Address1);
            builder.Property(x => x.Address2);
            builder.Property(x => x.City);
            builder.Property(x => x.State);
            builder.Property(x => x.ZipCode);
            builder.Property(x => x.CountryCode);
        }
    }
}
