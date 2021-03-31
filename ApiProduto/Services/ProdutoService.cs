using System.Collections.Generic;
using ApiProduto.Models;
using ApiProduto.Utils;
using MongoDB.Driver;

namespace ApiProduto.Services
{
    public class ProdutoService
    {
         private readonly IMongoCollection<Produto> _produtos;

        public ProdutoService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _produtos = database.GetCollection<Produto>(settings.ProdutoCollectionName);
        }

        public List<Produto> Get() =>
            _produtos.Find(produto => true).ToList();

        public Produto Get(string id) =>
            _produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();

        public Produto Create(Produto produto)
        {
            _produtos.InsertOne(produto);
            return produto;
        }

        public void Update(string id, Produto produtoIn) =>
            _produtos.ReplaceOne(produto => produto.Id == id, produtoIn);

        public void Remove(Produto produtoIn) =>
            _produtos.DeleteOne(produto => produto.Id == produtoIn.Id);

        public void Remove(string id) => 
            _produtos.DeleteOne(produto => produto.Id == id);  
    }
}