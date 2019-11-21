using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class MarcaDAO : IMarcaDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public MarcaDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<MarcaDTO> ObterTodasMarcas()
        {
            List<MarcaDTO> marcas = new List<MarcaDTO>();

            var sort = Builders<Marca>.Sort.Ascending(marca => marca.DescricaoMarca);

            var Marcaes = _context.CollectionMarca.Find(marca => true).Sort(sort).ToList() ;

           foreach (var item in Marcaes)
            {
                MarcaDTO v = new MarcaDTO{
                    IdMarca = item.IdMarca,
                    DescricaoMarca = item.DescricaoMarca
                };
                marcas.Add(v);
            }
            return marcas;
        }

        public MarcaDTO ObterMarcaPorId(string idMarca)
        {
            if(idMarca != null)
            {
                var resultado = _context.CollectionMarca.Find<Marca>(marca => marca.IdMarca == idMarca).FirstOrDefault();

                MarcaDTO marcaDTO = new MarcaDTO{
                    IdMarca = resultado.IdMarca,
                    DescricaoMarca = resultado.DescricaoMarca
                };
                return marcaDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterMarcaPorId() DAO";
            
            return null;
        }

        public void AdicionarNovaMarca(MarcaDTO marca)
        {
            if(marca != null)
            {
                Marca marcaNovo = new Marca{
                    DescricaoMarca = marca.DescricaoMarca.ToUpper()
                };
            
                _context.CollectionMarca.InsertOne(marcaNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoMarca() DAO";
        }

        public void AtualizarMarca(string idMarca, MarcaDTO marcaNew)
        {
            if((idMarca != null)&&(marcaNew != null))
            {
                Marca marcaNovo = new Marca{
                    IdMarca = idMarca,
                    DescricaoMarca = marcaNew.DescricaoMarca.ToUpper()
                };

                _context.CollectionMarca.ReplaceOne(marca => marca.IdMarca == idMarca, marcaNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarMarca() DAO";
        }

        public void ExcluirMarca(string idMarca)
        {
            if(idMarca != null)
            {
                _context.CollectionMarca.DeleteOne(marca => marca.IdMarca == idMarca);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirMarca() DAO";
        }
    }
}