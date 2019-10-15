using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
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