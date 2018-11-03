using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using template.Application.Interfaces.External;
using template.Domain.Entities;
using template.Persistence.Mongo.Client;
using template.Persistence.Mongo.Mappings;

namespace template.Persistence.Mongo.Repositories
{
    public class BillingInformationRepository : IBillingInformationRepository
    {
        private readonly IMongoCollection<BillingInformationMap> _collection;

        public BillingInformationRepository(MongoConnector connector)
        {
            _collection = connector.GetCollection<BillingInformationMap>("BillingInformation");
        }

        public Task CreateBillingInformation(BillingInformation billingInformation)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBillingInformation(string billingInformationId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BillingInformation> GetAllBillingInformations()
        {
            throw new System.NotImplementedException();
        }

        public BillingInformation GetBillingInformation(string billingInformationId)
        {
            throw new System.NotImplementedException();
        }

        public BillingInformation GetBillingInformationForCustomerId(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBillingInformation(BillingInformation update)
        {
            throw new System.NotImplementedException();
        }
    }
}
