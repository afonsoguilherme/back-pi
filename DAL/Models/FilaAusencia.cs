using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace back_sistema_tg.DAL.Models
{
    public class FilaAusencia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedorEmAusencia { get; set; }

        public Vendedor Vendedor { get; set;}
    }
}