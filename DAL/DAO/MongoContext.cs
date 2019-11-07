using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class MongoContext:IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Configuracoes> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Usuario> CollectionUsuario => _db.GetCollection<Usuario>("Usuario");
        public IMongoCollection<Vendedor> CollectionVendedor => _db.GetCollection<Vendedor>("Vendedor");
        public IMongoCollection<Movimento> CollectionMovimento => _db.GetCollection<Movimento>("Movimento");
        public IMongoCollection<VendaNaoSucedida> CollectionVendaNaoSucedida => _db.GetCollection<VendaNaoSucedida>("VendaNaoSucedida");
        public IMongoCollection<FilaEspera> CollectionFilaEspera => _db.GetCollection<FilaEspera>("FilaEspera");
        public IMongoCollection<FilaAtendimento> CollectionFilaAtendimento => _db.GetCollection<FilaAtendimento>("FilaAtendimento");
        public IMongoCollection<FilaAusencia> CollectionFilaAusencia => _db.GetCollection<FilaAusencia>("FilaAusencia");
    }
}