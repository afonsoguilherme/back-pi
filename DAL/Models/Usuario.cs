using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_pi.DAL.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Nome")]
        public string Nome { get; set; }
       
        [BsonElement("Login")]
        public string Login { get; set; }
        
        [BsonElement("Senha")]
        public string Senha { get; set; }
    }
}
