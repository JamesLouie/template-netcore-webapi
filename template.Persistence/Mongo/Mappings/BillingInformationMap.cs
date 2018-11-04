using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using template.Domain.Entities;

namespace template.Persistence.Mongo.Mappings
{
    internal class BillingInformationMap
    {
        internal BillingInformationMap()
        {
        }

        internal BillingInformationMap(BillingInformation billingInformation)
        {
            BillingInformationId = billingInformation.BillingInformationId;
            CreditCardNumber = billingInformation.CreditCardNumber;
            SecurityCode = billingInformation.SecurityCode;
            ExpirationDate = billingInformation.ExpirationDate;
            ReferenceCustomerId = billingInformation.ReferenceCustomerId;
            ReferenceBillingAddressId = billingInformation.BillingAddress?.ReferenceId;
        }

        // Specific to MongoDB implementation
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        internal Guid? ObjectId { get; set; }

        [BsonElement("billing_information_id")]
        internal string BillingInformationId { get; set; }

        [BsonElement("credit_card_number")]
        internal string CreditCardNumber { get; set; }

        [BsonElement("security_code")]
        internal string SecurityCode { get; set; }

        [BsonElement("expiration_date")]
        internal DateTime ExpirationDate { get; set; }

        // Foreign Key References

        [BsonElement("fk_customer_id")]
        internal string ReferenceCustomerId { get; set; }
        [BsonIgnore]
        internal CustomerMap Customer { get; set; }

        [BsonElement("fk_billing_address_id")]
        internal string ReferenceBillingAddressId { get; set; }
        [BsonIgnore]
        internal AddressMap BillingAddress { get; set; }

        internal BillingInformation MapToDomain()
        {
            return new BillingInformation
            {
                BillingInformationId = BillingInformationId,
                CreditCardNumber = CreditCardNumber,
                SecurityCode = SecurityCode,
                ExpirationDate = ExpirationDate,
                BillingAddress = BillingAddress?.MapToDomain(),
                ReferenceCustomerId = Customer?.CustomerId
            };
        }
    }
}
