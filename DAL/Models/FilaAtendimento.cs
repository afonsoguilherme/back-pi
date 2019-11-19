using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class FilaAtendimento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedorEmAtendimento { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}