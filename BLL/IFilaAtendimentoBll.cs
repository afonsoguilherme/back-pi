using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IFilaAtendimentoBll
    {
        List<FilaAtendimento> ObterVendedoresFilaAtendimento();
        void FinalizarAtendimento(string idVendedor);
    }
}