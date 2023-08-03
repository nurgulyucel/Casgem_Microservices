using CasgemMicroservices.Catalog.Setting.Abstract;

namespace CasgemMicroservices.Catalog.Setting.Concrete
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
