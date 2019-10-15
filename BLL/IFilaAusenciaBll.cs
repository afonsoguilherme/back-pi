using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IFilaAusenciaBll
    {
        List<FilaAusencia> ObterVendedoresFilaAusencia();
        void FinalizarAusencia(string idVendedor);
    }
}