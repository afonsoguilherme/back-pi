using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IFilaAusenciaDAO
    {
        List<FilaAusencia> ObterVendedoresFilaAusencia();
        void FinalizarAusencia(string idVendedor);
    }
}