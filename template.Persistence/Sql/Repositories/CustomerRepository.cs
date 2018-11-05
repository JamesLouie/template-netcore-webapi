using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Persistence.Sql.Mappings;

namespace template.Persistence.Sql.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(string customerId)
        {
            var customerResult = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == int.Parse(customerId));
            return customerResult?.MapToDomain();
        }

        public async Task CreateCustomer(Customer newCustomer)
        {
            var newCustomerMap = new CustomerMap(newCustomer);
            newCustomerMap.DateRegistered = DateTime.UtcNow;
            newCustomerMap.IsActive = true;

            _context.Customers.Add(newCustomerMap);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(string customerId)
        {
            var deleteResult = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == int.Parse(customerId));
            _context.Remove(deleteResult);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer update)
        {
            _context.Customers.Update(new CustomerMap(update));
            await _context.SaveChangesAsync();
        }
    }
}
