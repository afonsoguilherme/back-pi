using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace back_sistema_tg.DAL.Models
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

        [BsonElement("JustificativaVenda")]
        public string JustificativaVenda { get; set; }

        [BsonElement("InicioMovimento")]
        public DateTime InicioMovimento { get; set; }

        [BsonElement("FinalMovimento")]
        public DateTime FinalMovimento { get; set; }
    }
}