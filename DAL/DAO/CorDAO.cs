using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public class CorDAO : ICorDAO
    {
        public string Mensagem = "Mensagem";
        
        private readonly IMongoContext _context;  
        public CorDAO(IMongoContext context)
        {
            _context = context;
        }

        public List<CorDTO> ObterTodasCores()
        {
            List<CorDTO> cores = new List<CorDTO>();

            var sort = Builders<Cor>.Sort.Ascending(cor => cor.DescricaoCor);

            var Cores = _context.CollectionCor.Find(cor => true).Sort(sort).ToList() ;

           foreach (var item in Cores)
            {
                CorDTO v = new CorDTO{
                    IdCor = item.IdCor,
                    DescricaoCor = item.DescricaoCor
                };
                cores.Add(v);
            }
            return cores;
        }

        public CorDTO ObterCorPorId(string idCor)
        {
            if(idCor != null)
            {
                var resultado = _context.CollectionCor.Find<Cor>(cor => cor.IdCor == idCor).FirstOrDefault();

                CorDTO corDTO = new CorDTO{
                    IdCor = resultado.IdCor,
                    DescricaoCor = resultado.DescricaoCor
                };
                return corDTO;
            }
            
            this.Mensagem = "Falha ao executar o metodo ObterCorPorId() DAO";
            
            return null;
        }

        public void AdicionarNovaCor(CorDTO cor)
        {
            if(cor != null)
            {
                Cor corNovo = new Cor{
                    DescricaoCor = cor.DescricaoCor
                };
            
                _context.CollectionCor.InsertOne(corNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AdicionarNovoCor() DAO";
        }

        public void AtualizarCor(string idCor, CorDTO corNew)
        {
            if((idCor != null)&&(corNew != null))
            {
                Cor corNovo = new Cor{
                    IdCor = idCor,
                    DescricaoCor = corNew.DescricaoCor
                };

                _context.CollectionCor.ReplaceOne(cor => cor.IdCor == idCor, corNovo);
            }
            
            this.Mensagem = "Falha ao executar o metodo AtualizarCor() DAO";
        }

        public void ExcluirCor(string idCor)
        {
            if(idCor != null)
            {
                _context.CollectionCor.DeleteOne(cor => cor.IdCor == idCor);
            }
            
            this.Mensagem = "Falha ao executar o metodo ExcluirCor() DAO";
        }
    }
}