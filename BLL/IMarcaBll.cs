using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public interface IMarcaBll
    {
        void AdicionarNovaMarca(MarcaDTO marca);
        List<MarcaDTO> ObterTodasMarcas();
        MarcaDTO ObterMarcaPorId(string idMarca);
        void AtualizarMarca(string idMarca, MarcaDTO marcaNew);
        void ExcluirMarca(string idMarca);
    }
}
