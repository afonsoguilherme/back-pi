using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.DAO.Relatorios;

namespace back_pi.DAL.DAO
{
    public interface IMovimentoDAO
    {
        void AdicionarNovoMovimento(MovimentoDTO movimento);
        void FinalizarMovimento(MovimentoDTO movimento);
        List<MovimentoDTO> ObterTodosMovimentos();
        List<MovimentoDTO> MovimentosVendedores();
        List<MovimentoDTO> MovimentosVendedoresNãoSucedido(); 
        List<MovimentoDTO> ObterMovimentosPorVendedor(string idVendedor);
        List<MovimentoDTO> ObterMovimentosTipoVenda();
        List<MovimentoDTO> ObterMovimentosTipoAusencia();
        MovimentoDTO ObterMovimentoPorId(string idMovimento);
        void AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew);
        void ExcluirMovimento(string idMovimento);
        ICollection<Grafico> ObterGrafico();
    }
}