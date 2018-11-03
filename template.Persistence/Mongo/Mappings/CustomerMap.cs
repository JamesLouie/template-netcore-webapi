using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using template.Domain.Entities;

namespace template.Persistence.Mongo.Mappings
{
    public class CustomerMap
    {
        public CustomerMap()
        {
        }

        public CustomerMap(Customer customer)
        {
            CustomerId = (customer.CustomerId != null) ? Guid.Parse(customer.CustomerId) : (Guid?) null;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email?.CompleteEmailAddress;
            PhoneNumber = customer.PhoneNumber;
            DateRegistered = customer.DateRegistered;
        }

        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateRegistered { get; set; }

        public Customer MapToDomain()
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
