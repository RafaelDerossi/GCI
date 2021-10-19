namespace NinjaStore.Core.Data
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}