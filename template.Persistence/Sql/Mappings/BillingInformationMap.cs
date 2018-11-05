using System;
using template.Domain.Entities;
using template.Persistence.Sql.Utilities;

namespace template.Persistence.Sql.Mappings
{
    internal class BillingInformationMap
    {
        internal BillingInformationMap()
        {
        }

        // Might have to come back and verify whats the best way to represent foreign keys
        internal BillingInformationMap(BillingInformation billingInformation)
        {
            BillingInformationId = IntegerUtility.ParseOrDefault(billingInformation.BillingInformationId);
            CreditCardNumber = billingInformation.CreditCardNumber;
            SecurityCode = billingInformation.SecurityCode;
            ExpirationDate = billingInformation.ExpirationDate;
            ReferenceCustomerId =  IntegerUtility.ParseOrDefault(billingInformation.ReferenceCustomerId);
            ReferenceBillingAddressId = IntegerUtility.ParseOrDefault(billingInformation.BillingAddress?.ReferenceId);
        }

        internal int BillingInformationId { get; set; }
        internal string CreditCardNumber { get; set; }
        internal string SecurityCode { get; set; }
        internal DateTime ExpirationDate { get; set; }

        // Foreign Keys

        internal int ReferenceCustomerId { get; set; }
        internal virtual CustomerMap Customer { get; set; }
        internal int ReferenceBillingAddressId { get; set; }
        internal virtual AddressMap BillingAddress { get; set; }

        internal BillingInformation MapToDomain()
        {
            return new BillingInformation
            {
                BillingInformationId = BillingInformationId.ToString(),
                CreditCardNumber = CreditCardNumber,
                SecurityCode = SecurityCode,
                ExpirationDate = ExpirationDate,
                BillingAddress = BillingAddress?.MapToDomain(),
                ReferenceCustomerId = Customer?.CustomerId.ToString()
            };
        }
    }
}
