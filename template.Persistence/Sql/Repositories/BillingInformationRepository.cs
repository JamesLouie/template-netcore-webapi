using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Domain.Exceptions;
using template.Persistence.Sql.Mappings;

namespace template.Persistence.Sql.Repositories
{
    public class BillingInformationRepository : IBillingInformationRepository
    {
        private readonly ApplicationContext _context;

        public BillingInformationRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Look how to map the entity using includes()
        public async Task<BillingInformation> GetBillingInformation(string billingInformationId)
        {
            var billingInformationResult = await _context.BillingInformations
                .SingleOrDefaultAsync(x => x.BillingInformationId == int.Parse(billingInformationId));

            if (billingInformationResult == null)
                return null;

            var addressResult = await _context.Addresses
                .SingleOrDefaultAsync(x => x.AddressId == billingInformationResult.ReferenceBillingAddressId);

            if (addressResult == null)
                throw new RecordNotFoundException("Unable to resolve address");

            billingInformationResult.BillingAddress = addressResult;

            return billingInformationResult.MapToDomain();
        }

        public async Task CreateBillingInformation(BillingInformation billingInformation)
        {
            var addAddress = _context.Addresses.Add(new AddressMap(billingInformation.BillingAddress));
            await _context.SaveChangesAsync();

            var addBillingInformation = new BillingInformationMap(billingInformation);
            addBillingInformation.ReferenceBillingAddressId = addAddress.Entity.AddressId;

            _context.BillingInformations.Add(addBillingInformation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillingInformation(string billingInformationId)
        {
            var billingInformationResult = await _context.BillingInformations
                .SingleOrDefaultAsync(x => x.BillingInformationId == int.Parse(billingInformationId));

            var addressResult = await _context.Addresses
                .SingleOrDefaultAsync(x => x.AddressId == billingInformationResult.ReferenceBillingAddressId);

            _context.BillingInformations.Remove(billingInformationResult);
            _context.Addresses.Remove(addressResult);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillingInformation(BillingInformation update)
        {
            _context.BillingInformations.Update(new BillingInformationMap(update));
            _context.Addresses.Update(new AddressMap(update.BillingAddress));

            await _context.SaveChangesAsync();
        }

        public async Task<BillingInformation> GetBillingInformationForCustomerId(string customerId)
        {
            var billingInformationResult = await _context.BillingInformations
                .SingleOrDefaultAsync(x => x.ReferenceCustomerId == int.Parse(customerId));

            if (billingInformationResult == null)
                return null;

            var addressResult = await _context.Addresses
                .SingleOrDefaultAsync(x => x.AddressId == billingInformationResult.ReferenceBillingAddressId);

            if (addressResult == null)
                throw new RecordNotFoundException("Unable to resolve address");

            billingInformationResult.BillingAddress = addressResult;

            return billingInformationResult.MapToDomain();
        }
    }
}
