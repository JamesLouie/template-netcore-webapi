using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using template.Domain.Entities;

namespace template.Persistence.Mongo.Mappings
{
    internal class CustomerMap
    {
        internal CustomerMap()
        {
        }

        internal CustomerMap(Customer customer)
        {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email?.CompleteEmailAddress;
            PhoneNumber = customer.PhoneNumber;
            DateRegistered = customer.DateRegistered;
            IsActive = customer.IsActive;
        }

        // Specific to MongoDB implementation
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        internal Guid? ObjectId { get; set; }

        [BsonElement("customer_id")]
        internal string CustomerId { get; set; }

        [BsonElement("first_name")]
        internal string FirstName { get; set; }

        [BsonElement("last_name")]
        internal string LastName { get; set; }

        [BsonElement("email")]
        internal string Email { get; set; }

        [BsonElement("phone_number")]
        internal string PhoneNumber { get; set; }

        [BsonElement("date_registered")]
        internal DateTime? DateRegistered { get; set; }

        [BsonElement("is_active")]
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
