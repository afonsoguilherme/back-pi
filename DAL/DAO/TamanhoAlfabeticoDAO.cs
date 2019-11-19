using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class TamanhoAlfabeticoDAO : ITamanhoAlfabeticoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public TamanhoAlfabeticoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<TamanhoAlfabeticoDTO> ObterTodosTamanhosAlfabeticos()
        {
            List<TamanhoAlfabeticoDTO> tamanhosAlfabeticos = new List<TamanhoAlfabeticoDTO>();

            var sort = Builders<TamanhoAlfabetico>.Sort.Ascending(tamanhoAlfabetico => tamanhoAlfabetico.DescricaoTamanhoAlfabetico);

            var TamanhoAlfabeticoes = _context.CollectionTamanhoAlfabetico.Find(tamanhoAlfabetico => true).Sort(sort).ToList() ;

           foreach (var item in TamanhoAlfabeticoes)
            {
                TamanhoAlfabeticoDTO v = new TamanhoAlfabeticoDTO{
                    IdTamanhoAlfabetico = item.IdTamanhoAlfabetico,
                    DescricaoTamanhoAlfabetico = item.DescricaoTamanhoAlfabetico
                };
                tamanhosAlfabeticos.Add(v);
            }
            return tamanhosAlfabeticos;
        }

        public TamanhoAlfabeticoDTO ObterTamanhoAlfabeticoPorId(string idTamanhoAlfabetico)
        {
            if(idTamanhoAlfabetico != null)
            {
                var resultado = _context.CollectionTamanhoAlfabetico.Find<TamanhoAlfabetico>(tamanhoAlfabetico => tamanhoAlfabetico.IdTamanhoAlfabetico == idTamanhoAlfabetico).FirstOrDefault();

                TamanhoAlfabeticoDTO tamanhoAlfabeticoDTO = new TamanhoAlfabeticoDTO{
                    IdTamanhoAlfabetico = resultado.IdTamanhoAlfabetico,
                    DescricaoTamanhoAlfabetico = resultado.DescricaoTamanhoAlfabetico
                };
                return tamanhoAlfabeticoDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterTamanhoAlfabeticoPorId() DAO";
            
            return null;
        }

        public void AdicionarNovoTamanhoAlfabetico(TamanhoAlfabeticoDTO tamanhoAlfabetico)
        {
            if(tamanhoAlfabetico != null)
            {
                TamanhoAlfabetico tamanhoAlfabeticoNovo = new TamanhoAlfabetico{
                    DescricaoTamanhoAlfabetico = tamanhoAlfabetico.DescricaoTamanhoAlfabetico
                };
            
                _context.CollectionTamanhoAlfabetico.InsertOne(tamanhoAlfabeticoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoTamanhoAlfabetico() DAO";
        }

        public void AtualizarTamanhoAlfabetico(string idTamanhoAlfabetico, TamanhoAlfabeticoDTO tamanhoAlfabeticoNew)
        {
            if((idTamanhoAlfabetico != null)&&(tamanhoAlfabeticoNew != null))
            {
                TamanhoAlfabetico tamanhoAlfabeticoNovo = new TamanhoAlfabetico{
                    IdTamanhoAlfabetico = idTamanhoAlfabetico,
                    DescricaoTamanhoAlfabetico = tamanhoAlfabeticoNew.DescricaoTamanhoAlfabetico
                };

                _context.CollectionTamanhoAlfabetico.ReplaceOne(tamanhoAlfabetico => tamanhoAlfabetico.IdTamanhoAlfabetico == idTamanhoAlfabetico, tamanhoAlfabeticoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarTamanhoAlfabetico() DAO";
        }

        public void ExcluirTamanhoAlfabetico(string idTamanhoAlfabetico)
        {
            if(idTamanhoAlfabetico != null)
            {
                _context.CollectionTamanhoAlfabetico.DeleteOne(tamanhoAlfabetico => tamanhoAlfabetico.IdTamanhoAlfabetico == idTamanhoAlfabetico);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirTamanhoAlfabetico() DAO";
        }
    }
}