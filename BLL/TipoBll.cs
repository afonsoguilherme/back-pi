using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class TipoBll : ITipoBll
    {
        public string Mensagem = "Mensagem";

        public readonly ITipoDAO _tipoDAO;
        public TipoBll(ITipoDAO tipoDAO)
        {
            _tipoDAO = tipoDAO;
        }

        public List<TipoDTO> ObterTodosTipos()
        {
            var verifica = _tipoDAO.ObterTodosTipos();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosTipos() BLL executado tiporetamente";
            
            return verifica;
        }

        public TipoDTO ObterTipoPorId(string idTipo)
        {
            if((idTipo != null)&&(idTipo != ""))
            {
               return _tipoDAO.ObterTipoPorId(idTipo); 
            }  
            return null;
        }

        public void AdicionarNovoTipo(TipoDTO tipo)
        {
            if((tipo != null)&&(tipo.DescricaoTipo != null))
            {
                _tipoDAO.AdicionarNovoTipo(tipo);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovoTipo() BLL";
        }

        public void AtualizarTipo(string idTipo, TipoDTO tipoNew)
        {
            if((idTipo != null)&&(tipoNew != null))
            {
                _tipoDAO.AtualizarTipo(idTipo, tipoNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarTipo() BLL";
        }

        public void ExcluirTipo(string idTipo)
        {
            if((idTipo != null)&&(idTipo != ""))
            {
                _tipoDAO.ExcluirTipo(idTipo);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}