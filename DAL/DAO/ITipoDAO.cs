using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface ITipoDAO
    {
        void AdicionarNovoTipo(TipoDTO tipo);
        List<TipoDTO> ObterTodosTipos();
        TipoDTO ObterTipoPorId(string idTipo);
        void AtualizarTipo(string idTipo, TipoDTO tipoNew);
        void ExcluirTipo(string idTipo);
    }
}
