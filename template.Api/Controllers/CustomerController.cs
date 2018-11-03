using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using template.Api.Contracts.Customer;
using template.Application.Providers;

namespace template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerHandler _customerHandler;

        public CustomerController(ICustomerHandler customerHandler)
        {
            _customerHandler = customerHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string customerId)
        {
            var customer = await _customerHandler.GetCustomer(customerId);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerRequest request)
        {
            await _customerHandler.CreateCustomer(request.ToDomain());
            return Ok();
        }
    }
}