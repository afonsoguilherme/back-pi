using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IFilaAusenciaBll
    {
        List<FilaAusencia> ObterVendedoresFilaAusencia();
        void FinalizarAusencia(string idVendedor);
    }
}