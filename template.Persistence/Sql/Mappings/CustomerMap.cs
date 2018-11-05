using System;
using template.Domain.Entities;
using template.Persistence.Sql.Utilities;

namespace template.Persistence.Sql.Mappings
{
    internal class CustomerMap
    {
        internal CustomerMap()
        {
        }

        internal CustomerMap(Customer customer)
        {
            CustomerId = IntegerUtility.ParseOrDefault(customer.CustomerId);
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email?.CompleteEmailAddress;
            PhoneNumber = customer.PhoneNumber;
            DateRegistered = customer.DateRegistered;
            IsActive = customer.IsActive;
        }

        internal int CustomerId { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Email { get; set; }
        internal string PhoneNumber { get; set; }
        internal DateTime? DateRegistered { get; set; }
        internal bool IsActive { get; set; }

        internal Customer MapToDomain()
        {
            return new Customer
            {
                CustomerId = CustomerId.ToString(),
                FirstName = FirstName,
                LastName = LastName,
                Email = (Email != null) ? new Domain.ValueObjects.Email(Email) : null,
                PhoneNumber = PhoneNumber,
                DateRegistered = DateRegistered
            };
        }
    }
}
