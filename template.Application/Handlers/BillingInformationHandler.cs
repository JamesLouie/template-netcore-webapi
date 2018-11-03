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

        public BillingInformation GetBillingInformation(string billingInformationId)
        {
            return _billingInformationRepository.GetBillingInformation(billingInformationId);
        }

        public Task CreateBillingInformation(BillingInformation billingInformation)
        {
            return _billingInformationRepository.CreateBillingInformation(billingInformation);
        }

        public void UpdateBillingInformation(BillingInformation update)
        {
            _billingInformationRepository.UpdateBillingInformation(update);
        }

        public void DeleteBillingInformation(string billingInformationId)
        {
            _billingInformationRepository.DeleteBillingInformation(billingInformationId);
        }
    }
}
