using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class Marca
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdMarca { get; set; }
        
        [BsonElement("DescricaoMarca")]
        public string DescricaoMarca { get; set; }
    }
}
