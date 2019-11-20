using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class Tamanho
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTamanho { get; set; }
        
        [BsonElement("DescricaoTamanho")]
        public string DescricaoTamanho { get; set; }
    }
}
