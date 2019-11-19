using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class Tipo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTipo { get; set; }
        
        [BsonElement("DescricaoTipo")]
        public string DescricaoTipo { get; set; }
    }
}
