using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class FilaEsperaDAO : IFilaEsperaDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public FilaEsperaDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<FilaEspera> ObterVendedoresFilaEspera()
        {
            var Fila = _context.CollectionFilaEspera.Find(list => true).ToList();

            return Fila;
        }

        public void IniciarAtendimento(string idVendedor)
        {
            if(idVendedor != null)
            {
                var vendedor = _context.CollectionVendedor.Find(v => v.IdVendedor == idVendedor).FirstOrDefault();
                
                _context.CollectionFilaEspera.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                
                FilaAtendimento novoItem = new FilaAtendimento{
                    Vendedor = vendedor
                };
                _context.CollectionFilaAtendimento.InsertOne(novoItem);
            }
            
            this.Mensagem = "Falha ao executar o metodo IniciarAtendimento() DAO";
        }

        public void IniciarAusencia(string idVendedor)
        {
            if(idVendedor != null)
            {
                var objVendedor = _context.CollectionVendedor.Find(v => v.IdVendedor == idVendedor).FirstOrDefault();
                
                _context.CollectionFilaEspera.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                
                FilaAusencia vendedor = new FilaAusencia{
                    Vendedor = objVendedor
                };
                _context.CollectionFilaAusencia.InsertOne(vendedor);
            }
            
            this.Mensagem = "Falha ao executar o metodo IniciarAusencia() DAO";
        }
    }
}