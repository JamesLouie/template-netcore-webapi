using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using template.Domain.ValueObjects;

namespace template.Persistence.Mongo.Mappings
{
    internal class AddressMap
    {
        internal AddressMap()
        {
        }

        internal AddressMap(Address address)
        {
            AddressId = address.ReferenceId;
            Address1 = address.Address1;
            Address2 = address.Address2;
            City = address.City;
            State = address.State;
            ZipCode = address.ZipCode;
            CountryCode = address.CountryCode;
        }

        // Specific to MongoDB implementation
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        internal Guid? ObjectId { get; set; }

        [BsonElement("address_id")]
        internal string AddressId { get; set; }

        [BsonElement("address_one")]
        internal string Address1 { get; set; }

        [BsonElement("address_two")]
        internal string Address2 { get; set; }

        [BsonElement("city")]
        internal string City { get; set; }

        [BsonElement("state")]
        internal string State { get; set; }

        [BsonElement("zip_code")]
        internal string ZipCode { get; set; }

        [BsonElement("country_code")]
        internal string CountryCode { get; set; }

        internal Address MapToDomain()
        {
            return new Address
            {
                ReferenceId = AddressId,
                Address1 = Address1,
                Address2 = Address2,
                City = City,
                State = State,
                ZipCode = ZipCode,
                CountryCode = CountryCode
            };
        }
    }
}
