using MongoDB.Driver;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IMongoContext
    {
        IMongoCollection<Usuario> CollectionUsuario { get; }
        IMongoCollection<Vendedor> CollectionVendedor { get; }
        IMongoCollection<Movimento> CollectionMovimento { get; }
        IMongoCollection<VendaNaoSucedida> CollectionVendaNaoSucedida { get; }
        IMongoCollection<FilaEspera> CollectionFilaEspera { get; }
        IMongoCollection<FilaAtendimento> CollectionFilaAtendimento { get; }
        IMongoCollection<FilaAusencia> CollectionFilaAusencia { get; }
    }
}