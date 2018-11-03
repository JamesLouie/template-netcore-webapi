using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Mappings;

namespace template.Persistence.Mongo.Repositories
{
    /// <summary>
    /// Implementation Notes
    /// 
    /// Currently not sure what is the best way to have an identifier for the customer that is both human readable and performant.
    /// Using ObjectId as the identifier is hard to refer back to when looking at the database, but creating an additional field which
    /// will be searched off of doesn't seem like a great idea either.
    /// 
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<CustomerMap> _collection;

        public CustomerRepository(MongoConnector connector)
        {
            _collection = connector.GetCollection<CustomerMap>("Customer");
        }

        public async Task<Customer> GetCustomer(string customerId)
        {
            var result = await _collection.Find(x => x.CustomerId == customerId).SingleAsync();
            return result.MapToDomain();
        }

        public async Task CreateCustomer(Customer newCustomer)
        {
            var newCustomerMap = new CustomerMap(newCustomer);
            newCustomerMap.CustomerId = Guid.NewGuid().ToString();
            newCustomerMap.DateRegistered = DateTime.UtcNow;
            newCustomerMap.IsActive = true;

            await _collection.InsertOneAsync(newCustomerMap);
        }

        public async Task DeleteCustomer(string customerId)
        {
            await _collection.FindOneAndDeleteAsync(x => x.CustomerId == customerId);
        }

        public async Task UpdateCustomer(Customer update)
        {
            await _collection.FindOneAndReplaceAsync(x => x.CustomerId == update.CustomerId, new CustomerMap(update));
        }
    }
}
