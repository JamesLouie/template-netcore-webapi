using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using template.Domain.Entities;

namespace template.Persistence.Mongo.Mappings
{
    public class CustomerMap
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
        public Guid? ObjectId { get; set; }

        [BsonElement("customer_id")]
        public string CustomerId { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone_number")]
        public string PhoneNumber { get; set; }

        [BsonElement("date_registered")]
        public DateTime? DateRegistered { get; set; }

        [BsonElement("is_active")]
        public bool IsActive { get; set; }

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
