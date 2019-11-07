using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class VendaNaoSucedida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendaNaoSucedida { get; set; }

        [BsonElement("IdVendedor")]
        public string IdVendedor { get; set; }

        [BsonElement("IdMovimento")]
        public string IdMovimento { get; set; }
        
        [BsonElement("TipoProduto")]
        public string TipoProduto { get; set; }

        [BsonElement("MarcaProduto")]
        public string MarcaProduto { get; set; }

        [BsonElement("CorProduto")]
        public string CorProduto { get; set; }

        [BsonElement("NumeroProduto")]
        public string NumeroProduto { get; set; }

        [BsonElement("DescricaoProduto")]
        public string DescricaoProduto { get; set; }

        [BsonElement("NomeCliente")]
        public string NomeCliente { get; set; }

        [BsonElement("TelefoneCliente")]
        public string TelefoneCliente { get; set; }
    }
}