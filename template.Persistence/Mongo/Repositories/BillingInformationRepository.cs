using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Domain.Exceptions;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Mappings;

namespace template.Persistence.Mongo.Repositories
{
    public class BillingInformationRepository : IBillingInformationRepository
    {
        private readonly IMongoCollection<BillingInformationMap> _billingInformationCollection;
        private readonly IMongoCollection<AddressMap> _addressCollection;

        public BillingInformationRepository(MongoConnector connector)
        {
            _billingInformationCollection = connector.GetCollection<BillingInformationMap>("BillingInformation");
            _addressCollection = connector.GetCollection<AddressMap>("Address");
        }

        // The expectation for this repository methods to return null in the general not found case, but if you expect to find the record and
        // don't, throw an exception. In this case BillingInformation may not exist, but when we query for Address from a reference in BillingInformation
        // it should exist.
        public async Task<BillingInformation> GetBillingInformation(string billingInformationId)
        {
            var billingInformationResult =  await _billingInformationCollection
                .Find(x => x.BillingInformationId == billingInformationId)
                .SingleOrDefaultAsync();

            if (billingInformationResult == null)
                return null;

            var addressResult = await _addressCollection
                .Find(x => x.AddressId == billingInformationResult.ReferenceBillingAddressId)
                .SingleOrDefaultAsync();

            if (addressResult == null)
                throw new RecordNotFoundException("Unable to find expected address with for billing information");

            billingInformationResult.BillingAddress = addressResult;

            return billingInformationResult.MapToDomain();
        }

        public async Task CreateBillingInformation(BillingInformation billingInformation)
        {
            var insertAddress = new AddressMap(billingInformation.BillingAddress);
            insertAddress.AddressId = Guid.NewGuid().ToString();

            await _addressCollection.InsertOneAsync(insertAddress);

            var insertBillingInformation = new BillingInformationMap(billingInformation);
            insertBillingInformation.BillingInformationId = Guid.NewGuid().ToString();
            insertBillingInformation.ReferenceBillingAddressId = insertAddress.AddressId;

            await _billingInformationCollection.InsertOneAsync(insertBillingInformation);
        }

        public async Task DeleteBillingInformation(string billingInformationId)
        {
            var deletedEntry = await _billingInformationCollection.FindOneAndDeleteAsync(x => x.BillingInformationId == billingInformationId);
            await _addressCollection.DeleteOneAsync(x => x.AddressId == deletedEntry.ReferenceBillingAddressId);
        }

        public async Task UpdateBillingInformation(BillingInformation update)
        {
            await _billingInformationCollection
                .ReplaceOneAsync(x => x.BillingInformationId == update.BillingInformationId, new BillingInformationMap(update));
            await _addressCollection
                .ReplaceOneAsync(x => x.AddressId == update.BillingAddress.ReferenceId, new AddressMap(update.BillingAddress));
        }

        public async Task<BillingInformation> GetBillingInformationForCustomerId(string customerId)
        {
            var billingInformationResult = await _billingInformationCollection
                .Find(x => x.ReferenceCustomerId == customerId)
                .SingleOrDefaultAsync();

            if (billingInformationResult == null)
                return null;

            var addressResult = await _addressCollection
                .Find(x => x.AddressId == billingInformationResult.ReferenceBillingAddressId)
                .SingleOrDefaultAsync();

            if (addressResult == null)
                throw new RecordNotFoundException("Unable to find expected address with for billing information");

            billingInformationResult.BillingAddress = addressResult;

            return billingInformationResult.MapToDomain();
        }
    }
}
