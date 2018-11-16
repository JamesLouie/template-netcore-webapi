namespace template.Persistence.Mongo.Configurations
{
    public interface MongoConfig
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
