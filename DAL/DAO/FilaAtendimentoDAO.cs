using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class FilaAtendimentoDAO : IFilaAtendimentoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public FilaAtendimentoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<FilaAtendimento> ObterVendedoresFilaAtendimento()
        {
            var Fila = _context.CollectionFilaAtendimento.Find(list => true).ToList();

            return Fila;
        }

        public void FinalizarAtendimento(string idVendedor)
        {
            if(idVendedor != null)
            {
                var objVendedor = _context.CollectionVendedor.Find(v => v.IdVendedor == idVendedor).FirstOrDefault();
                
                _context.CollectionFilaAtendimento.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                
                FilaEspera vendedor = new FilaEspera{
                    Vendedor = objVendedor
                };
                _context.CollectionFilaEspera.InsertOne(vendedor);
            }
            
            this.Mensagem = "Falha ao executar o metodo FinalizarAtendimento() DAO";
        }
    }
}