using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using template.Api.Contracts.BillingInformation;
using template.Application.Providers;

namespace template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInformationController : ControllerBase
    {
        private readonly IBillingInformationHandler _billingInformationHandler;

        public BillingInformationController(IBillingInformationHandler billingInformationHandler)
        {
            _billingInformationHandler = billingInformationHandler;
        }

        [HttpGet]
        [Route("~/api/customer/{customerId}/billinginformation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BillingInformationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillingInformationByCustomerId(string customerId)
        {
            var billingInformation = await _billingInformationHandler.GetBillingInformationForCustomerId(customerId);
            if (billingInformation != null)
                return Ok(new BillingInformationResponse(billingInformation));

            return NotFound();
        }

        [HttpGet]
        [Route("{billingInformationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BillingInformationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillingInformation(string billingInformationId)
        {
            var billingInformation = await _billingInformationHandler.GetBillingInformation(billingInformationId);
            if (billingInformation != null)
                return Ok(new BillingInformationResponse(billingInformation));

            return NotFound();
        }

        [HttpPost]
        [Route("~/api/customer/{customerId}/billinginformation")]
        public async Task<IActionResult> CreateBillingInformation(string customerId, CreateBillingInformationRequest request)
        {
            var billingInformation = request.ToDomain();
            billingInformation.ReferenceCustomerId = customerId;

            await _billingInformationHandler.CreateBillingInformation(billingInformation);

            return Ok();
        }
    }
}