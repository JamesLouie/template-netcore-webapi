using template.Domain.ValueObjects;
using template.Persistence.Sql.Utilities;

namespace template.Persistence.Sql.Mappings
{
    internal class AddressMap
    {
        internal AddressMap()
        {
        }

        internal AddressMap(Address address)
        {
            AddressId = IntegerUtility.ParseOrDefault(address.ReferenceId);
            Address1 = address.Address1;
            Address2 = address.Address2;
            City = address.City;
            State = address.State;
            ZipCode = address.ZipCode;
            CountryCode = address.CountryCode;
        }

        internal int AddressId { get; set; }
        internal string Address1 { get; set; }
        internal string Address2 { get; set; }
        internal string City { get; set; }
        internal string State { get; set; }
        internal string ZipCode { get; set; }
        internal string CountryCode { get; set; }

        internal Address MapToDomain()
        {
            return new Address
            {
                ReferenceId = AddressId.ToString(),
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
