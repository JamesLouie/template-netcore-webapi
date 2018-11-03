using MongoDB.Driver;

namespace template.Persistence.Mongo.Client
{
    public class MongoConnector
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoConnector(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
