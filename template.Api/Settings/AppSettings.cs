using template.Persistence.Mongo.Configurations;
using template.Persistence.Sql.Configurations;

namespace template.Api.Settings
{
    public class AppSettings
    {
        public MongoDatabase Mongo { get; set; }
        public SqlServerDatabase SqlServer { get; set; }
        public WebClient WebClient { get; set; }
    }

    public class MongoDatabase : MongoConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class SqlServerDatabase : SqlServerConfig
    {
        public string ConnectionString { get; set; }
    }

    public class WebClient
    {
        public string BaseAddress { get; set; }
    }
}
