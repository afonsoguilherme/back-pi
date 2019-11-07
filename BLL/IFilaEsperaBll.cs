using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IFilaEsperaBll
    {
        List<FilaEspera> ObterVendedoresFilaEspera();
        void IniciarAtendimento(string idVendedor);
        void IniciarAusencia(string idVendedor);
    }
}