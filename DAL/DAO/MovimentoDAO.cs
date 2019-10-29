using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class MovimentoDAO : IMovimentoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public MovimentoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<MovimentoDTO> ObterTodosMovimentos()
        {
            List<MovimentoDTO> movimentos = new List<MovimentoDTO>();

            var sort = Builders<Movimento>.Sort.Ascending(movimento => movimento.IdMovimento);

            var Movimentos = _context.CollectionMovimento.Find(movimento => true).Sort(sort).ToList() ;

           foreach (var item in Movimentos)
            {
                var vendedor = _context.CollectionVendedor.Find<Vendedor>(v => v.IdVendedor == item.IdVendedor).FirstOrDefault();

                MovimentoDTO m = new MovimentoDTO{
                    IdMovimento = item.IdMovimento,
                    IdVendedor = item.IdVendedor,
                    TipoMovimento = item.TipoMovimento,
                    StatusVenda = item.StatusVenda,
                    JustificativaVenda = item.JustificativaVenda,
                    InicioMovimento = item.InicioMovimento,
                    FinalMovimento = item.FinalMovimento,
                    Vendedor = vendedor
                };
                movimentos.Add(m);
            }
            return movimentos;
        }
        
        public MovimentoDTO ObterMovimentoPorId(string idMovimento)
        {
            if(idMovimento != null)
            {
                var item = _context.CollectionMovimento.Find<Movimento>(movimento => movimento.IdMovimento == idMovimento).FirstOrDefault();
                
                var vendedor = _context.CollectionVendedor.Find<Vendedor>(v => v.IdVendedor == item.IdVendedor).FirstOrDefault();

                MovimentoDTO movimentoDTO = new MovimentoDTO{
                    IdMovimento = item.IdMovimento,
                    IdVendedor = item.IdVendedor,
                    TipoMovimento = item.TipoMovimento,
                    StatusVenda = item.StatusVenda,
                    JustificativaVenda = item.JustificativaVenda,
                    InicioMovimento = item.InicioMovimento,
                    FinalMovimento = item.FinalMovimento,
                    Vendedor = vendedor
                };
                return movimentoDTO;
            }           
            this.Mensagem = "Falha ao executar o metodo ObterMovimentoPorId() DAO";
            
            return null;
        }

        public List<MovimentoDTO> ObterMovimentosPorVendedor(string idVendedor)
        {
            List<MovimentoDTO> movimentos = new List<MovimentoDTO>();

            var sort = Builders<Movimento>.Sort.Ascending(movimento => movimento.IdMovimento);

            var Movimentos = _context.CollectionMovimento.Find(movimento => movimento.IdVendedor == idVendedor).Sort(sort).ToList() ;

           foreach (var item in Movimentos)
            {
                var vendedor = _context.CollectionVendedor.Find<Vendedor>(v => v.IdVendedor == item.IdVendedor).FirstOrDefault();

                MovimentoDTO m = new MovimentoDTO{
                    IdMovimento = item.IdMovimento,
                    IdVendedor = item.IdVendedor,
                    TipoMovimento = item.TipoMovimento,
                    StatusVenda = item.StatusVenda,
                    JustificativaVenda = item.JustificativaVenda,
                    InicioMovimento = item.InicioMovimento,
                    FinalMovimento = item.FinalMovimento,
                    Vendedor = vendedor
                };
                movimentos.Add(m);
            }
            return movimentos;
        }
        
        public void AdicionarNovoMovimento(MovimentoDTO movimento)
        {
            if( movimento != null)
            {
                Movimento movimentoNovo = new Movimento{
                    IdVendedor = movimento.IdVendedor,
                    TipoMovimento = movimento.TipoMovimento,
                    StatusVenda = movimento.StatusVenda,
                    JustificativaVenda = movimento.JustificativaVenda,
                    InicioMovimento = movimento.InicioMovimento,
                    FinalMovimento = movimento.FinalMovimento
                };
            
                _context.CollectionMovimento.InsertOne(movimentoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoMovimento() DAO";
        }

        public void FinalizarMovimento(MovimentoDTO movimento)
        {
            if( movimento != null)
            {
                var sort = Builders<Movimento>.Sort.Descending(m => m.IdMovimento);

                var item = _context.CollectionMovimento.Find<Movimento>(m => m.IdVendedor == movimento.IdVendedor).Sort(sort).FirstOrDefault();

                Movimento movimentoNovo = new Movimento{
                    IdMovimento = item.IdMovimento,
                    IdVendedor = item.IdVendedor,
                    TipoMovimento = item.TipoMovimento,
                    StatusVenda = movimento.StatusVenda,
                    JustificativaVenda = movimento.JustificativaVenda,
                    InicioMovimento = item.InicioMovimento,
                    FinalMovimento = movimento.FinalMovimento,
                };
            
                _context.CollectionMovimento.ReplaceOne(m => m.IdMovimento == item.IdMovimento, movimentoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarMovimento() DAO";
        }
        
        public void AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew)
        {
            if((idMovimento != null)&&(movimentoNew != null))
            {
                Movimento movimentoNovo = new Movimento{
                    IdMovimento = idMovimento,
                    IdVendedor = movimentoNew.IdVendedor,
                    TipoMovimento = movimentoNew.TipoMovimento,
                    StatusVenda = movimentoNew.StatusVenda,
                    JustificativaVenda = movimentoNew.JustificativaVenda,
                    InicioMovimento = movimentoNew.InicioMovimento,
                    FinalMovimento = movimentoNew.FinalMovimento
                };

                _context.CollectionMovimento.ReplaceOne(movimento => movimento.IdMovimento == idMovimento, movimentoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarMovimento() DAO";
        }
        
        public void ExcluirMovimento(string idMovimento)
        {
            if(idMovimento != null)
            {
                _context.CollectionMovimento.DeleteOne(movimento => movimento.IdMovimento == idMovimento);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirMovimento() DAO";
        }
    }
}