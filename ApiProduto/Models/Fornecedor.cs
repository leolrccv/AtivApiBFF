using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiProduto.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}