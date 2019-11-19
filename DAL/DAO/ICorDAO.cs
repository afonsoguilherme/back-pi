using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface ICorDAO
    {
        void AdicionarNovaCor(CorDTO cor);
        List<CorDTO> ObterTodasCores();
        CorDTO ObterCorPorId(string idCor);
        void AtualizarCor(string idCor, CorDTO corNew);
        void ExcluirCor(string idCor);
    }
}
