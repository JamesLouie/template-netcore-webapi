using MongoDB.Driver;
using template.Persistence.Mongo.Configurations;

namespace template.Persistence.Mongo.Client
{
    public class MongoConnector
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoConnector(MongoConfig config)
        {
            _client = new MongoClient(config.ConnectionString);
            _database = _client.GetDatabase(config.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
