using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
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
                var vendedor = _context.CollectionVendedor.Find<Vendedor>(m => m.IdVendedor == item.IdVendedor).FirstOrDefault();
                var movimento = _context.CollectionMovimento.Find<Movimento>(m => m.IdMovimento == item.IdMovimento).FirstOrDefault();
    
                VendaNaoSucedidaDTO vns = new VendaNaoSucedidaDTO{
                    IdVendaNaoSucedida = item.IdVendaNaoSucedida,
                    TipoProduto = item.TipoProduto,
                    MarcaProduto = item.MarcaProduto,
                    CorProduto = item.CorProduto,
                    NumeroProduto = item.NumeroProduto,
                    DescricaoProduto = item.DescricaoProduto,
                    NomeCliente = item.NomeCliente,
                    TelefoneCliente = item.TelefoneCliente,
                    IdVendedor = item.IdVendedor,
                    Vendedor = vendedor,
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
                var vendedor = _context.CollectionVendedor.Find<Vendedor>(m => m.IdVendedor == resultado.IdVendedor).FirstOrDefault();
                var movimento = _context.CollectionMovimento.Find<Movimento>(m => m.IdMovimento == resultado.IdMovimento).FirstOrDefault();
    
                VendaNaoSucedidaDTO vendaNaoSucedidaDTO = new VendaNaoSucedidaDTO{
                    IdVendaNaoSucedida = resultado.IdVendaNaoSucedida,
                    TipoProduto = resultado.TipoProduto,
                    MarcaProduto = resultado.MarcaProduto,
                    CorProduto = resultado.CorProduto,
                    NumeroProduto = resultado.NumeroProduto,
                    DescricaoProduto = resultado.DescricaoProduto,
                    NomeCliente = resultado.NomeCliente,
                    TelefoneCliente = resultado.TelefoneCliente,
                    IdVendedor = resultado.IdVendedor,
                    Vendedor = vendedor,
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
                var sort = Builders<Movimento>.Sort.Descending(m => m.IdMovimento);

                var item = _context.CollectionMovimento.Find<Movimento>(m => m.IdVendedor == vendaNaoSucedida.IdVendedor).Sort(sort).FirstOrDefault();

                VendaNaoSucedida vendaNaoSucedidaNova = new VendaNaoSucedida{
                    IdVendedor = vendaNaoSucedida.IdVendedor,
                    IdMovimento = item.IdMovimento,
                    TipoProduto = vendaNaoSucedida.TipoProduto,
                    MarcaProduto = vendaNaoSucedida.MarcaProduto,
                    CorProduto = vendaNaoSucedida.CorProduto,
                    NumeroProduto = vendaNaoSucedida.NumeroProduto,
                    DescricaoProduto = vendaNaoSucedida.DescricaoProduto,
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
                    IdVendedor = vendaNaoSucedidaNew.IdVendedor,
                    IdMovimento = vendaNaoSucedidaNew.IdMovimento,
                    TipoProduto = vendaNaoSucedidaNew.TipoProduto,
                    MarcaProduto = vendaNaoSucedidaNew.MarcaProduto,
                    CorProduto = vendaNaoSucedidaNew.CorProduto,
                    NumeroProduto = vendaNaoSucedidaNew.NumeroProduto,
                    DescricaoProduto = vendaNaoSucedidaNew.DescricaoProduto,
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