using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class TamanhoNumericoBll : ITamanhoNumericoBll
    {
        public string Mensagem = "Mensagem";

        public readonly ITamanhoNumericoDAO _tamanhoNumericoDAO;
        public TamanhoNumericoBll(ITamanhoNumericoDAO tamanhoNumericoDAO)
        {
            _tamanhoNumericoDAO = tamanhoNumericoDAO;
        }

        public List<TamanhoNumericoDTO> ObterTodosTamanhosNumericos()
        {
            var verifica = _tamanhoNumericoDAO.ObterTodosTamanhosNumericos();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosTamanhosNumericos() BLL executado tamanhoNumericoretamente";
            
            return verifica;
        }

        public TamanhoNumericoDTO ObterTamanhoNumericoPorId(string idTamanhoNumerico)
        {
            if((idTamanhoNumerico != null)&&(idTamanhoNumerico != ""))
            {
               return _tamanhoNumericoDAO.ObterTamanhoNumericoPorId(idTamanhoNumerico); 
            }  
            return null;
        }

        public void AdicionarNovoTamanhoNumerico(TamanhoNumericoDTO tamanhoNumerico)
        {
            if((tamanhoNumerico != null)&&(tamanhoNumerico.DescricaoTamanhoNumerico != null))
            {
                _tamanhoNumericoDAO.AdicionarNovoTamanhoNumerico(tamanhoNumerico);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovoTamanhoNumerico() BLL";
        }

        public void AtualizarTamanhoNumerico(string idTamanhoNumerico, TamanhoNumericoDTO tamanhoNumericoNew)
        {
            if((idTamanhoNumerico != null)&&(tamanhoNumericoNew != null))
            {
                _tamanhoNumericoDAO.AtualizarTamanhoNumerico(idTamanhoNumerico, tamanhoNumericoNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarTamanhoNumerico() BLL";
        }

        public void ExcluirTamanhoNumerico(string idTamanhoNumerico)
        {
            if((idTamanhoNumerico != null)&&(idTamanhoNumerico != ""))
            {
                _tamanhoNumericoDAO.ExcluirTamanhoNumerico(idTamanhoNumerico);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}