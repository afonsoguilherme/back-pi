using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class FilaEsperaBll : IFilaEsperaBll
    {
        public string Mensagem = "Mensagem";

        public readonly IFilaEsperaDAO _FilaEsperaDAO;
        public FilaEsperaBll(IFilaEsperaDAO FilaEsperaDAO)
        {
            _FilaEsperaDAO = FilaEsperaDAO;
        }

        public List<FilaEspera> ObterVendedoresFilaEspera()
        {
            var verifica = _FilaEsperaDAO.ObterVendedoresFilaEspera();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedoresFilaEspera() BLL executado corretamente";
            
            return verifica;
        }

        public void IniciarAtendimento(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
                _FilaEsperaDAO.IniciarAtendimento(idVendedor);
            }
            this.Mensagem = "Falha na execucao do metodo IniciarAtendimento() BLL";
        }

        public void IniciarAusencia(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
                _FilaEsperaDAO.IniciarAusencia(idVendedor);
            }
            this.Mensagem = "Falha na execucao do metodo IniciarAusencia() BLL";
        }
    }
}