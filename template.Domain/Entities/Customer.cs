using System;
using template.Domain.ValueObjects;

namespace template.Domain.Entities
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateRegistered { get; set; }
        public bool IsActive { get; set; }

        public BillingInformation BillingInformation { get; set; }
    }
}
