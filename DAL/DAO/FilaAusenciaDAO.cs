using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class FilaAusenciaDAO : IFilaAusenciaDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public FilaAusenciaDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<FilaAusencia> ObterVendedoresFilaAusencia()
        {
            var Fila = _context.CollectionFilaAusencia.Find(list => true).ToList();

            return Fila;
        }

        public void FinalizarAusencia(string idVendedor)
        {
            if(idVendedor != null)
            {
                var objVendedor = _context.CollectionVendedor.Find(v => v.IdVendedor == idVendedor).FirstOrDefault();
                
                _context.CollectionFilaAusencia.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                
                FilaEspera vendedor = new FilaEspera{
                    Vendedor = objVendedor
                };
                _context.CollectionFilaEspera.InsertOne(vendedor);
            }
            
            this.Mensagem = "Falha ao executar o metodo FinalizarAusencia() DAO";
        }
    }
}