using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
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