using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Mappings;

namespace template.Persistence.Mongo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<CustomerMap> _collection;

        public CustomerRepository(MongoConnector connector)
        {
            _collection = connector.GetCollection<CustomerMap>("Customer");
        }

        public async Task<Customer> GetCustomer(string customerId)
        {
            var result = await _collection.Find(x => x.CustomerId == Guid.Parse(customerId)).SingleAsync();
            return result.MapToDomain();
        }

        public async Task CreateCustomer(Customer newCustomer)
        {
            await _collection.InsertOneAsync(new CustomerMap(newCustomer));
        }

        public async Task DeleteCustomer(string customerId)
        {
            await _collection.FindOneAndDeleteAsync(x => x.CustomerId == Guid.Parse(customerId));
        }

        public async Task UpdateCustomer(Customer update)
        {
            await _collection.FindOneAndReplaceAsync(x => x.CustomerId == Guid.Parse(update.CustomerId), new CustomerMap(update));
        }
    }
}
