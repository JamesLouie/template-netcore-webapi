using System.Threading.Tasks;
using template.Application.Interfaces.External;
using template.Application.Providers;
using template.Domain.Entities;

namespace template.Application.Handlers
{
    public class BillingInformationHandler : IBillingInformationHandler
    {
        private readonly IBillingInformationRepository _billingInformationRepository;

        public BillingInformationHandler(IBillingInformationRepository billingInformationRepository)
        {
            _billingInformationRepository = billingInformationRepository;
        }

        public Task<BillingInformation> GetBillingInformation(string billingInformationId)
        {
            return _billingInformationRepository.GetBillingInformation(billingInformationId);
        }

        public Task CreateBillingInformation(BillingInformation billingInformation)
        {
            return _billingInformationRepository.CreateBillingInformation(billingInformation);
        }

        public Task UpdateBillingInformation(BillingInformation update)
        {
            return _billingInformationRepository.UpdateBillingInformation(update);
        }

        public Task DeleteBillingInformation(string billingInformationId)
        {
            return _billingInformationRepository.DeleteBillingInformation(billingInformationId);
        }

        public Task<BillingInformation> GetBillingInformationForCustomerId(string customerId)
        {
            return _billingInformationRepository.GetBillingInformationForCustomerId(customerId);
        }
    }
}
