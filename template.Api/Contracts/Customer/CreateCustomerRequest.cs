using System;

namespace template.Api.Contracts.Customer
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateRegistered { get; set; }
        public bool IsActive { get; set; }

        public Domain.Entities.Customer ToDomain()
        {
            return new Domain.Entities.Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = (Email != null) ? new Domain.ValueObjects.Email(Email) : null,
                PhoneNumber = PhoneNumber,
                DateRegistered = DateRegistered,
                IsActive = IsActive
            };
        }
    }
}
