namespace ApiProduto.Utils
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string ProdutoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}