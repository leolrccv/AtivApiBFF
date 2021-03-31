namespace ApiProduto.Utils
{
    public interface IMongoDBSettings
    {
        string ProdutoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}