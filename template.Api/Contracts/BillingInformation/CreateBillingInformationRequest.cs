using System;

namespace template.Api.Contracts.BillingInformation
{
    public class CreateBillingInformationRequest
    {
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Billing Address
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }

        public Domain.Entities.BillingInformation ToDomain()
        {
            return new Domain.Entities.BillingInformation
            {
                CreditCardNumber = CreditCardNumber,
                SecurityCode = SecurityCode,
                ExpirationDate = ExpirationDate,
                BillingAddress = new Domain.ValueObjects.Address
                {
                    Address1 = Address1,
                    Address2 = Address2,
                    City = City,
                    State = State,
                    ZipCode = ZipCode,
                    CountryCode = CountryCode
                }
            };
        }
    }
}
