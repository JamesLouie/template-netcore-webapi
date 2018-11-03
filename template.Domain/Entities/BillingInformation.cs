using System;
using template.Domain.ValueObjects;

namespace template.Domain.Entities
{
    public class BillingInformation
    {
        public string BillingInformationId { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Address BillingAddress { get; set; }

        public string ReferenceCustomerId { get; set; }
    }
}
