using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class CorBll : ICorBll
    {
        public string Mensagem = "Mensagem";

        public readonly ICorDAO _corDAO;
        public CorBll(ICorDAO corDAO)
        {
            _corDAO = corDAO;
        }

        public List<CorDTO> ObterTodasCores()
        {
            var verifica = _corDAO.ObterTodasCores();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodasCores() BLL executado corretamente";
            
            return verifica;
        }

        public CorDTO ObterCorPorId(string idCor)
        {
            if((idCor != null)&&(idCor != ""))
            {
               return _corDAO.ObterCorPorId(idCor); 
            }  
            return null;
        }

        public void AdicionarNovaCor(CorDTO cor)
        {
            if((cor != null)&&(cor.DescricaoCor != null))
            {
                _corDAO.AdicionarNovaCor(cor);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovaCor() BLL";
        }

        public void AtualizarCor(string idCor, CorDTO corNew)
        {
            if((idCor != null)&&(corNew != null))
            {
                _corDAO.AtualizarCor(idCor, corNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarCor() BLL";
        }

        public void ExcluirCor(string idCor)
        {
            if((idCor != null)&&(idCor != ""))
            {
                _corDAO.ExcluirCor(idCor);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}