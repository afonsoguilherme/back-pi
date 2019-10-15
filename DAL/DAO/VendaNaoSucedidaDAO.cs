using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class VendaNaoSucedidaDAO : IVendaNaoSucedidaDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public VendaNaoSucedidaDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<VendaNaoSucedidaDTO> ObterTodasVendasNaoSucedidas()
        {
            List<VendaNaoSucedidaDTO> vendasNaoSucedidas = new List<VendaNaoSucedidaDTO>();

            var sort = Builders<VendaNaoSucedida>.Sort.Ascending(vendaNaoSucedida => vendaNaoSucedida.IdVendaNaoSucedida);

            var VendaNaoSucedidas = _context.CollectionVendaNaoSucedida.Find(vendaNaoSucedida => true).Sort(sort).ToList() ;
           
           foreach (var item in VendaNaoSucedidas)
            {
                var movimento = _context.CollectionMovimento.Find<Movimento>(m => m.IdMovimento == item.IdMovimento).FirstOrDefault();
    
                VendaNaoSucedidaDTO vns = new VendaNaoSucedidaDTO{
                    IdVendaNaoSucedida = item.IdVendaNaoSucedida,
                    ModeloProduto = item.ModeloProduto,
                    CorProduto = item.CorProduto,
                    NumeroProduto = item.NumeroProduto,
                    NomeCliente = item.NomeCliente,
                    TelefoneCliente = item.TelefoneCliente,
                    IdMovimento = item.IdMovimento,
                    Movimento = movimento
                };
                vendasNaoSucedidas.Add(vns);
            }
            return vendasNaoSucedidas;
        }
        
        public VendaNaoSucedidaDTO ObterVendaNaoSucedidaPorId(string idVendaNaoSucedida)
        {
            if(idVendaNaoSucedida != null)
            {
                var resultado = _context.CollectionVendaNaoSucedida.Find<VendaNaoSucedida>(vendaNaoSucedida => vendaNaoSucedida.IdVendaNaoSucedida == idVendaNaoSucedida).FirstOrDefault();
                
                var movimento = _context.CollectionMovimento.Find<Movimento>(m => m.IdMovimento == resultado.IdMovimento).FirstOrDefault();
    
                VendaNaoSucedidaDTO vendaNaoSucedidaDTO = new VendaNaoSucedidaDTO{
                    IdVendaNaoSucedida = resultado.IdVendaNaoSucedida,
                    ModeloProduto = resultado.ModeloProduto,
                    CorProduto = resultado.CorProduto,
                    NumeroProduto = resultado.NumeroProduto,
                    NomeCliente = resultado.NomeCliente,
                    TelefoneCliente = resultado.TelefoneCliente,
                    IdMovimento = resultado.IdMovimento,
                    Movimento = movimento
                };
                return vendaNaoSucedidaDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterVendaNaoSucedidaPorId() DAO";
            
            return null;
        }
        
        public void AdicionarNovaVendaNaoSucedida(VendaNaoSucedidaDTO vendaNaoSucedida)
        {
            if(vendaNaoSucedida != null)
            {
                VendaNaoSucedida vendaNaoSucedidaNova = new VendaNaoSucedida{
                    IdMovimento = vendaNaoSucedida.IdMovimento,
                    ModeloProduto = vendaNaoSucedida.ModeloProduto,
                    CorProduto = vendaNaoSucedida.CorProduto,
                    NumeroProduto = vendaNaoSucedida.NumeroProduto,
                    NomeCliente = vendaNaoSucedida.NomeCliente,
                    TelefoneCliente = vendaNaoSucedida.TelefoneCliente
                };
            
                _context.CollectionVendaNaoSucedida.InsertOne(vendaNaoSucedidaNova);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovaVendaNaoSucedida() DAO";
        }

        public void AtualizarVendaNaoSucedida(string idVendaNaoSucedida, VendaNaoSucedidaDTO vendaNaoSucedidaNew)
        {
            if((idVendaNaoSucedida != null)&&(vendaNaoSucedidaNew != null))
            {
                VendaNaoSucedida vendaNaoSucedidaNova = new VendaNaoSucedida{
                    IdVendaNaoSucedida = idVendaNaoSucedida,
                    IdMovimento = vendaNaoSucedidaNew.IdMovimento,
                    ModeloProduto = vendaNaoSucedidaNew.ModeloProduto,
                    CorProduto = vendaNaoSucedidaNew.CorProduto,
                    NumeroProduto = vendaNaoSucedidaNew.NumeroProduto,
                    NomeCliente = vendaNaoSucedidaNew.NomeCliente,
                    TelefoneCliente = vendaNaoSucedidaNew.TelefoneCliente
                };

                _context.CollectionVendaNaoSucedida.ReplaceOne(vendaNaoSucedida => vendaNaoSucedida.IdVendaNaoSucedida == idVendaNaoSucedida, vendaNaoSucedidaNova);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarVendaNaoSucedida() DAO";
        }

        public void ExcluirVendaNaoSucedida(string idVendaNaoSucedida)
        {
            if(idVendaNaoSucedida != null)
            {
                _context.CollectionVendaNaoSucedida.DeleteOne(vendaNaoSucedida => vendaNaoSucedida.IdVendaNaoSucedida == idVendaNaoSucedida);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirVendaNaoSucedida() DAO";
        }
    }
}