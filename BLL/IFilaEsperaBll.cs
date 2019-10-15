using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IFilaEsperaBll
    {
        List<FilaEspera> ObterVendedoresFilaEspera();
        void IniciarAtendimento(string idVendedor);
        void IniciarAusencia(string idVendedor);
    }
}