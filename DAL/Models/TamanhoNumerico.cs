using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class TamanhoAlfabetico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTamanhoAlfabetico { get; set; }
        
        [BsonElement("DescricaoTamanhoAlfabetico")]
        public string DescricaoTamanhoAlfabetico { get; set; }
    }
}
