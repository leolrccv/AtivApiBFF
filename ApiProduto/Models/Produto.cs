using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiProduto.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}