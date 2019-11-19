using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class Cor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdCor { get; set; }
        
        [BsonElement("DescricaoCor")]
        public string DescricaoCor { get; set; }
    }
}
