using System;

namespace template.Api.Contracts.BillingInformation
{
    public class BillingInformationResponse
    {
        public BillingInformationResponse(Domain.Entities.BillingInformation billingInformation)
        {
            BillingInformationId = billingInformation.BillingInformationId;
            CreditCardNumber = billingInformation.CreditCardNumber;
            SecurityCode = billingInformation.SecurityCode;
            ExpirationDate = billingInformation.ExpirationDate;
            Address1 = billingInformation.BillingAddress?.Address1;
            Address2 = billingInformation.BillingAddress?.Address2;
            City = billingInformation.BillingAddress?.City;
            State = billingInformation.BillingAddress?.State;
            ZipCode = billingInformation.BillingAddress?.ZipCode;
            CountryCode = billingInformation.BillingAddress?.CountryCode;
        }

        public string BillingInformationId { get; set; }
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
    }
}
