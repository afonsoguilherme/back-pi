using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class VendedorDAO : IVendedorDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public VendedorDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<VendedorDTO> ObterTodosVendedores()
        {
            List<VendedorDTO> vendedores = new List<VendedorDTO>();

            var sort = Builders<Vendedor>.Sort.Ascending(vendedor => vendedor.NomeVendedor);

            var Vendedores = _context.CollectionVendedor.Find(vendedor => true).Sort(sort).ToList() ;

           foreach (var item in Vendedores)
            {
                VendedorDTO v = new VendedorDTO{
                    IdVendedor = item.IdVendedor,
                    NomeVendedor = item.NomeVendedor,
                    CodigoVendedor = item.CodigoVendedor,
                    ImagemVendedor = item.ImagemVendedor
                };
                vendedores.Add(v);
            }
            return vendedores;
        }

        public VendedorDTO ObterVendedorPorId(string idVendedor)
        {
            if(idVendedor != null)
            {
                var resultado = _context.CollectionVendedor.Find<Vendedor>(vendedor => vendedor.IdVendedor == idVendedor).FirstOrDefault();

                VendedorDTO vendedorDTO = new VendedorDTO{
                    IdVendedor = resultado.IdVendedor,
                    NomeVendedor = resultado.NomeVendedor,
                    CodigoVendedor = resultado.CodigoVendedor,
                    ImagemVendedor = resultado.ImagemVendedor
                };
                return vendedorDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterVendedorPorId() DAO";
            
            return null;
        }

        public VendedorDTO ObterVendedorPorCodigo(string codigoVendedor)
        {
            if(codigoVendedor != null)
            {
                var resultado = _context.CollectionVendedor.Find<Vendedor>(vendedor => vendedor.CodigoVendedor == codigoVendedor).FirstOrDefault();

                VendedorDTO vendedorDTO = new VendedorDTO{
                    IdVendedor = resultado.IdVendedor,
                    NomeVendedor = resultado.NomeVendedor,
                    CodigoVendedor = resultado.CodigoVendedor,
                    ImagemVendedor = resultado.ImagemVendedor
                };
                return vendedorDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterVendedorPorId() DAO";
            
            return null;
        }

        public VendedorDTO ObterVendedorPorNome(string nomeVendedor)
        {
            if(nomeVendedor != null)
            {
                var resultado = _context.CollectionVendedor.Find<Vendedor>(vendedor => vendedor.NomeVendedor == nomeVendedor).FirstOrDefault();

                VendedorDTO vendedorDTO = new VendedorDTO{
                    IdVendedor = resultado.IdVendedor,
                    NomeVendedor = resultado.NomeVendedor,
                    CodigoVendedor = resultado.CodigoVendedor,
                    ImagemVendedor = resultado.ImagemVendedor
                };
                return vendedorDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterVendedorPorNome() DAO";
            
            return null;
        }

        public void AdicionarNovoVendedor(VendedorDTO vendedor)
        {
            if(vendedor != null)
            {
                Vendedor vendedorNovo = new Vendedor{
                    NomeVendedor = vendedor.NomeVendedor,
                    CodigoVendedor = vendedor.CodigoVendedor,
                    ImagemVendedor = vendedor.ImagemVendedor
                };
            
                _context.CollectionVendedor.InsertOne(vendedorNovo);

                FilaEspera novoItem = new FilaEspera{
                    Vendedor = vendedorNovo
                };

                _context.CollectionFilaEspera.InsertOne(novoItem);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoVendedor() DAO";
        }

        public void AtualizarVendedor(string idVendedor, VendedorDTO vendedorNew)
        {
            if((idVendedor != null)&&(vendedorNew != null))
            {
                Vendedor vendedorNovo = new Vendedor{
                    IdVendedor = idVendedor,
                    NomeVendedor = vendedorNew.NomeVendedor,
                    CodigoVendedor = vendedorNew.CodigoVendedor,
                    ImagemVendedor = vendedorNew.ImagemVendedor
                };

                _context.CollectionVendedor.ReplaceOne(vendedor => vendedor.IdVendedor == idVendedor, vendedorNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarVendedor() DAO";
        }

        public void ExcluirVendedor(string idVendedor)
        {
            if(idVendedor != null)
            {
                _context.CollectionVendedor.DeleteOne(vendedor => vendedor.IdVendedor == idVendedor);

                var procuraEmEspera = _context.CollectionFilaEspera.Find<FilaEspera>(list => list.Vendedor.IdVendedor == idVendedor).FirstOrDefault();
                var procuraEmAtendimento = _context.CollectionFilaAtendimento.Find<FilaAtendimento>(list => list.Vendedor.IdVendedor == idVendedor).FirstOrDefault();
                var procuraEmAusencia = _context.CollectionFilaAusencia.Find<FilaAusencia>(list => list.Vendedor.IdVendedor == idVendedor).FirstOrDefault();
            
                if(procuraEmEspera != null){
                     _context.CollectionFilaEspera.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                }

                if(procuraEmAtendimento != null){
                     _context.CollectionFilaAtendimento.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                }

                if(procuraEmAusencia != null){
                     _context.CollectionFilaAusencia.DeleteOne(list => list.Vendedor.IdVendedor == idVendedor);
                }          
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirVendedor() DAO";
        }
    }
}