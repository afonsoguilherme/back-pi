using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public interface ITamanhoBll
    {
        void AdicionarNovoTamanho(TamanhoDTO tamanho);
        List<TamanhoDTO> ObterTodosTamanhoss();
        TamanhoDTO ObterTamanhoPorId(string idTamanho);
        void AtualizarTamanho(string idTamanho, TamanhoDTO tamanhoNew);
        void ExcluirTamanho(string idTamanho);
    }
}
