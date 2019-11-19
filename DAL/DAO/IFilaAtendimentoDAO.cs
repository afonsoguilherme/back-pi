using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IFilaAtendimentoDAO
    {
        List<FilaAtendimento> ObterVendedoresFilaAtendimento();
        void FinalizarAtendimento(string idVendedor);
    }
}