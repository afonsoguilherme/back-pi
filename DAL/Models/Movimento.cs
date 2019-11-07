using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace back_pi.DAL.Models
{
    public class Movimento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdMovimento { get; set; }
        
        [BsonElement("IdVendedor")]
        public string IdVendedor { get; set; }

        [BsonElement("TipoMovimento")]
        public string TipoMovimento { get; set; }

        [BsonElement("StatusVenda")]
        public bool StatusVenda { get; set; }

        [BsonElement("HorarioMovimento")]
        public Horario HorarioMovimento { get; set; }
    }
}