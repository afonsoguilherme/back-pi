using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class VendaNaoSucedida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendaNaoSucedida { get; set; }

        [BsonElement("IdMovimento")]
        public string IdMovimento { get; set; }

        [BsonElement("ModeloProduto")]
        public string ModeloProduto { get; set; }

        [BsonElement("CorProduto")]
        public string CorProduto { get; set; }

        [BsonElement("NumeroProduto")]
        public string NumeroProduto { get; set; }

        [BsonElement("NomeCliente")]
        public string NomeCliente { get; set; }

        [BsonElement("TelefoneCliente")]
        public string TelefoneCliente { get; set; }
    }
}