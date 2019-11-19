using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IFilaEsperaDAO
    {
        List<FilaEspera> ObterVendedoresFilaEspera();
        void IniciarAtendimento(string idVendedor);
        void IniciarAusencia(string idVendedor);
    }
}