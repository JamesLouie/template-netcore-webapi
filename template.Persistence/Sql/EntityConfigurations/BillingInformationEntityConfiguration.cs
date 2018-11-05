using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using template.Persistence.Sql.Mappings;

namespace template.Persistence.Sql.EntityConfigurations
{
    internal class BillingInformationEntityConfiguration : IEntityTypeConfiguration<BillingInformationMap>
    {
        public void Configure(EntityTypeBuilder<BillingInformationMap> builder)
        {
            builder.ToTable("BillingInformation").HasKey(x => x.BillingInformationId);
            builder.Property(x => x.CreditCardNumber);
            builder.Property(x => x.SecurityCode);
            builder.Property(x => x.ExpirationDate);

            // Foreign Keys
            builder.Property(x => x.ReferenceCustomerId).IsRequired();
            builder.Property(x => x.ReferenceBillingAddressId).IsRequired();
        }
    }
}
