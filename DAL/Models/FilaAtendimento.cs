using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace back_sistema_tg.DAL.Models
{
    public class FilaAtendimento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVendedorEmAtendimento { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}