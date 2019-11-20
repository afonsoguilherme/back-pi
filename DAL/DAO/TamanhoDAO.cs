using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class TamanhoDAO : ITamanhoDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public TamanhoDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<TamanhoDTO> ObterTodosTamanhoss()
        {
            List<TamanhoDTO> tamanhoss = new List<TamanhoDTO>();

            var sort = Builders<Tamanho>.Sort.Ascending(tamanho => tamanho.DescricaoTamanho);

            var Tamanhoes = _context.CollectionTamanho.Find(tamanho => true).Sort(sort).ToList() ;

           foreach (var item in Tamanhoes)
            {
                TamanhoDTO v = new TamanhoDTO{
                    IdTamanho = item.IdTamanho,
                    DescricaoTamanho = item.DescricaoTamanho
                };
                tamanhoss.Add(v);
            }
            return tamanhoss;
        }

        public TamanhoDTO ObterTamanhoPorId(string idTamanho)
        {
            if(idTamanho != null)
            {
                var resultado = _context.CollectionTamanho.Find<Tamanho>(tamanho => tamanho.IdTamanho == idTamanho).FirstOrDefault();

                TamanhoDTO tamanhoDTO = new TamanhoDTO{
                    IdTamanho = resultado.IdTamanho,
                    DescricaoTamanho = resultado.DescricaoTamanho
                };
                return tamanhoDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterTamanhoPorId() DAO";
            
            return null;
        }

        public void AdicionarNovoTamanho(TamanhoDTO tamanho)
        {
            if(tamanho != null)
            {
                Tamanho tamanhoNovo = new Tamanho{
                    DescricaoTamanho = tamanho.DescricaoTamanho
                };
            
                _context.CollectionTamanho.InsertOne(tamanhoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoTamanho() DAO";
        }

        public void AtualizarTamanho(string idTamanho, TamanhoDTO tamanhoNew)
        {
            if((idTamanho != null)&&(tamanhoNew != null))
            {
                Tamanho tamanhoNovo = new Tamanho{
                    IdTamanho = idTamanho,
                    DescricaoTamanho = tamanhoNew.DescricaoTamanho
                };

                _context.CollectionTamanho.ReplaceOne(tamanho => tamanho.IdTamanho == idTamanho, tamanhoNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarTamanho() DAO";
        }

        public void ExcluirTamanho(string idTamanho)
        {
            if(idTamanho != null)
            {
                _context.CollectionTamanho.DeleteOne(tamanho => tamanho.IdTamanho == idTamanho);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirTamanho() DAO";
        }
    }
}