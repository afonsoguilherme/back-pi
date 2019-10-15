using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace back_sistema_tg.DAL.Models
{
    public class FilaEspera
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedorEmEspera { get; set; }

        public Vendedor Vendedor { get; set;}
    }
}