using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class FilaAusencia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedorEmAusencia { get; set; }

        public Vendedor Vendedor { get; set;}
    }
}