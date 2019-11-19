using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class TamanhoNumerico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTamanhoNumerico { get; set; }
        
        [BsonElement("DescricaoTamanhoNumerico")]
        public string DescricaoTamanhoNumerico { get; set; }
    }
}
