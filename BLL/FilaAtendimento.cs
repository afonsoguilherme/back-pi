using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public class FilaAtendimentoBll : IFilaAtendimentoBll
    {
        public string Mensagem = "Mensagem";

        public readonly IFilaAtendimentoDAO _FilaAtendimentoDAO;
        public FilaAtendimentoBll(IFilaAtendimentoDAO FilaAtendimentoDAO)
        {
            _FilaAtendimentoDAO = FilaAtendimentoDAO;
        }

        public List<FilaAtendimento> ObterVendedoresFilaAtendimento()
        {
            var verifica = _FilaAtendimentoDAO.ObterVendedoresFilaAtendimento();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedoresFilaAtendimento() BLL executado corretamente";
            
            return verifica;
        }

        public void FinalizarAtendimento(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
                _FilaAtendimentoDAO.FinalizarAtendimento(idVendedor);
            }
            this.Mensagem = "Falha na execucao do metodo FinalizarAtendimento() BLL";
        }
    }
}