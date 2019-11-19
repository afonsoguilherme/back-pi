using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class TamanhoNumericoDAO : ITamanhoNumericoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public TamanhoNumericoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<TamanhoNumericoDTO> ObterTodosTamanhosNumericos()
        {
            List<TamanhoNumericoDTO> tamanhosNumericos = new List<TamanhoNumericoDTO>();

            var sort = Builders<TamanhoNumerico>.Sort.Ascending(tamanhoNumerico => tamanhoNumerico.DescricaoTamanhoNumerico);

            var TamanhoNumericoes = _context.CollectionTamanhoNumerico.Find(tamanhoNumerico => true).Sort(sort).ToList() ;

           foreach (var item in TamanhoNumericoes)
            {
                TamanhoNumericoDTO v = new TamanhoNumericoDTO{
                    IdTamanhoNumerico = item.IdTamanhoNumerico,
                    DescricaoTamanhoNumerico = item.DescricaoTamanhoNumerico
                };
                tamanhosNumericos.Add(v);
            }
            return tamanhosNumericos;
        }

        public TamanhoNumericoDTO ObterTamanhoNumericoPorId(string idTamanhoNumerico)
        {
            if(idTamanhoNumerico != null)
            {
                var resultado = _context.CollectionTamanhoNumerico.Find<TamanhoNumerico>(tamanhoNumerico => tamanhoNumerico.IdTamanhoNumerico == idTamanhoNumerico).FirstOrDefault();

                TamanhoNumericoDTO tamanhoNumericoDTO = new TamanhoNumericoDTO{
                    IdTamanhoNumerico = resultado.IdTamanhoNumerico,
                    DescricaoTamanhoNumerico = resultado.DescricaoTamanhoNumerico
                };
                return tamanhoNumericoDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterTamanhoNumericoPorId() DAO";
            
            return null;
        }

        public void AdicionarNovoTamanhoNumerico(TamanhoNumericoDTO tamanhoNumerico)
        {
            if(tamanhoNumerico != null)
            {
                TamanhoNumerico tamanhoNumericoNovo = new TamanhoNumerico{
                    DescricaoTamanhoNumerico = tamanhoNumerico.DescricaoTamanhoNumerico
                };
            
                _context.CollectionTamanhoNumerico.InsertOne(tamanhoNumericoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoTamanhoNumerico() DAO";
        }

        public void AtualizarTamanhoNumerico(string idTamanhoNumerico, TamanhoNumericoDTO tamanhoNumericoNew)
        {
            if((idTamanhoNumerico != null)&&(tamanhoNumericoNew != null))
            {
                TamanhoNumerico tamanhoNumericoNovo = new TamanhoNumerico{
                    IdTamanhoNumerico = idTamanhoNumerico,
                    DescricaoTamanhoNumerico = tamanhoNumericoNew.DescricaoTamanhoNumerico
                };

                _context.CollectionTamanhoNumerico.ReplaceOne(tamanhoNumerico => tamanhoNumerico.IdTamanhoNumerico == idTamanhoNumerico, tamanhoNumericoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarTamanhoNumerico() DAO";
        }

        public void ExcluirTamanhoNumerico(string idTamanhoNumerico)
        {
            if(idTamanhoNumerico != null)
            {
                _context.CollectionTamanhoNumerico.DeleteOne(tamanhoNumerico => tamanhoNumerico.IdTamanhoNumerico == idTamanhoNumerico);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirTamanhoNumerico() DAO";
        }
    }
}