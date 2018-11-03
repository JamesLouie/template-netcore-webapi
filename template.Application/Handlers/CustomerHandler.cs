using System.Threading.Tasks;
using template.Application.Interfaces.External;
using template.Application.Providers;
using template.Domain.Entities;

namespace template.Application.Handlers
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> GetCustomer(string customerId)
        {
            return _customerRepository.GetCustomer(customerId);
        }

        public Task CreateCustomer(Customer newCustomer)
        {
            return _customerRepository.CreateCustomer(newCustomer);
        }

        public async Task UpdateCustomer(Customer update)
        {
            await _customerRepository.UpdateCustomer(update);
        }

        public async Task DeleteCustomer(string customerId)
        {
            await _customerRepository.DeleteCustomer(customerId);
        }
    }
}
