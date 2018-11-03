using System.Threading.Tasks;
using template.Domain.Entities;

namespace template.Application.Providers
{
    public interface IBillingInformationHandler
    {
        BillingInformation GetBillingInformation(string billingInformationId);
        Task CreateBillingInformation(BillingInformation billingInformation);
        void UpdateBillingInformation(BillingInformation update);
        void DeleteBillingInformation(string billingInformationId);
    }
}
