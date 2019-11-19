using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public interface ICorBll
    {
        void AdicionarNovaCor(CorDTO cor);
        List<CorDTO> ObterTodasCores();
        CorDTO ObterCorPorId(string idCor);
        void AtualizarCor(string idCor, CorDTO corNew);
        void ExcluirCor(string idCor);
    }
}
