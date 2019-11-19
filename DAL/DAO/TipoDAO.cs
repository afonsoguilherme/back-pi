using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class TipoDAO : ITipoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public TipoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<TipoDTO> ObterTodosTipos()
        {
            List<TipoDTO> tipos = new List<TipoDTO>();

            var sort = Builders<Tipo>.Sort.Ascending(tipo => tipo.DescricaoTipo);

            var Tipoes = _context.CollectionTipo.Find(tipo => true).Sort(sort).ToList() ;

           foreach (var item in Tipoes)
            {
                TipoDTO v = new TipoDTO{
                    IdTipo = item.IdTipo,
                    DescricaoTipo = item.DescricaoTipo
                };
                tipos.Add(v);
            }
            return tipos;
        }

        public TipoDTO ObterTipoPorId(string idTipo)
        {
            if(idTipo != null)
            {
                var resultado = _context.CollectionTipo.Find<Tipo>(tipo => tipo.IdTipo == idTipo).FirstOrDefault();

                TipoDTO tipoDTO = new TipoDTO{
                    IdTipo = resultado.IdTipo,
                    DescricaoTipo = resultado.DescricaoTipo
                };
                return tipoDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterTipoPorId() DAO";
            
            return null;
        }

        public void AdicionarNovoTipo(TipoDTO tipo)
        {
            if(tipo != null)
            {
                Tipo tipoNovo = new Tipo{
                    DescricaoTipo = tipo.DescricaoTipo
                };
            
                _context.CollectionTipo.InsertOne(tipoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoTipo() DAO";
        }

        public void AtualizarTipo(string idTipo, TipoDTO tipoNew)
        {
            if((idTipo != null)&&(tipoNew != null))
            {
                Tipo tipoNovo = new Tipo{
                    IdTipo = idTipo,
                    DescricaoTipo = tipoNew.DescricaoTipo
                };

                _context.CollectionTipo.ReplaceOne(tipo => tipo.IdTipo == idTipo, tipoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarTipo() DAO";
        }

        public void ExcluirTipo(string idTipo)
        {
            if(idTipo != null)
            {
                _context.CollectionTipo.DeleteOne(tipo => tipo.IdTipo == idTipo);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirTipo() DAO";
        }
    }
}