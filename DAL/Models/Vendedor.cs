using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Vendedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedor { get; set; }

        [BsonElement("NomeVendedor")]
        public string NomeVendedor { get; set; }

        [BsonElement("CodigoVendedor")]
        public string CodigoVendedor { get; set; }

        [BsonElement("ImagemVendedor")]
        public string ImagemVendedor { get; set; }
    }
}