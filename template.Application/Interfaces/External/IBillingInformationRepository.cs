using System.Collections.Generic;
using System.Threading.Tasks;
using template.Domain.Entities;

namespace template.Application.Interfaces.External
{
    public interface IBillingInformationRepository
    {
        BillingInformation GetBillingInformation(string billingInformationId);
        Task CreateBillingInformation(BillingInformation billingInformation);
        void UpdateBillingInformation(BillingInformation update);
        void DeleteBillingInformation(string billingInformationId);

        IEnumerable<BillingInformation> GetAllBillingInformations();

        BillingInformation GetBillingInformationForCustomerId(string customerId);
    }
}
