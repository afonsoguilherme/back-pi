using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface ITamanhoNumericoDAO
    {
        void AdicionarNovoTamanhoNumerico(TamanhoNumericoDTO tamanhoNumerico);
        List<TamanhoNumericoDTO> ObterTodosTamanhosNumericos();
        TamanhoNumericoDTO ObterTamanhoNumericoPorId(string idTamanhoNumerico);
        void AtualizarTamanhoNumerico(string idTamanhoNumerico, TamanhoNumericoDTO tamanhoNumericoNew);
        void ExcluirTamanhoNumerico(string idTamanhoNumerico);
    }
}
