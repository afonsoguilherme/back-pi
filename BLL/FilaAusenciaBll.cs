using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public class FilaAusenciaBll : IFilaAusenciaBll
    {
        public string Mensagem = "Mensagem";

        public readonly IFilaAusenciaDAO _FilaAusenciaDAO;
        public FilaAusenciaBll(IFilaAusenciaDAO FilaAusenciaDAO)
        {
            _FilaAusenciaDAO = FilaAusenciaDAO;
        }

        public List<FilaAusencia> ObterVendedoresFilaAusencia()
        {
            var verifica = _FilaAusenciaDAO.ObterVendedoresFilaAusencia();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedoresFilaAusencia() BLL executado corretamente";
            
            return verifica;
        }

        public void FinalizarAusencia(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
                _FilaAusenciaDAO.FinalizarAusencia(idVendedor);
            }
            this.Mensagem = "Falha na execucao do metodo FinalizarAusencia() BLL";
        }
    }
}