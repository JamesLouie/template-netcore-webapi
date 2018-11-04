using System.Threading.Tasks;
using template.Domain.Entities;

namespace template.Application.Providers
{
    public interface IBillingInformationHandler
    {
        Task<BillingInformation> GetBillingInformation(string billingInformationId);
        Task CreateBillingInformation(BillingInformation billingInformation);
        Task UpdateBillingInformation(BillingInformation update);
        Task DeleteBillingInformation(string billingInformationId);

        Task<BillingInformation> GetBillingInformationForCustomerId(string customerId);
    }
}
