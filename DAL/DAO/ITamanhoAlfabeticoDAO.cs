using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface ITamanhoAlfabeticoDAO
    {
        void AdicionarNovoTamanhoAlfabetico(TamanhoAlfabeticoDTO tamanhoAlfabetico);
        List<TamanhoAlfabeticoDTO> ObterTodosTamanhosAlfabeticos();
        TamanhoAlfabeticoDTO ObterTamanhoAlfabeticoPorId(string idTamanhoAlfabetico);
        void AtualizarTamanhoAlfabetico(string idTamanhoAlfabetico, TamanhoAlfabeticoDTO tamanhoAlfabeticoNew);
        void ExcluirTamanhoAlfabetico(string idTamanhoAlfabetico);
    }
}
