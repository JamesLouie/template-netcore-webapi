using System;
using System.Net.Http;
using System.Threading.Tasks;
using template.Application.Interfaces.External;
using template.Domain.Entities;

namespace template.Persistence.WebClient
{
    public class CustomerServiceAgent : ICustomerRepository
    {
        private readonly HttpClient _client;

        public CustomerServiceAgent(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task CreateCustomer(Customer newCustomer)
        {
            var response = await _client.GetAsync("/api/customers");
        }

        public Task DeleteCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomer(string customerId)
        {
            var response = await _client.GetAsync("/api/customers");

            return null;
        }

        public Task UpdateCustomer(Customer update)
        {
            throw new NotImplementedException();
        }
    }
}
