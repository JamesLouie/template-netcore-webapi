namespace template.Api
{
    public class AppSettings
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
