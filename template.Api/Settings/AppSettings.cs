namespace template.Api.Settings
{
    public class AppSettings
    {
        public MongoDatabase Mongo { get; set; }
        public SqlServerDatabase SqlServer { get; set; }
    }

    public class MongoDatabase
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class SqlServerDatabase
    {
        public string ConnectionString { get; set; }
    }
}
