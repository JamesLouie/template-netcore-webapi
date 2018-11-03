﻿using System.Threading.Tasks;
using template.Domain.Entities;

namespace template.Application.Providers
{
    public interface ICustomerHandler
    {
        Task<Customer> GetCustomer(string customerId);
        Task CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer update);
        Task DeleteCustomer(string customerId);
    }
}
