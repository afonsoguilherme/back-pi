using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IMovimentoBll
    {
        void AdicionarNovoMovimento(MovimentoDTO movimento);
        void FinalizarMovimento(MovimentoDTO movimento);
        List<MovimentoDTO> ObterTodosMovimentos();
        List<MovimentoDTO> ObterMovimentosPorVendedor(string idVendedor);
        List<MovimentoDTO> ObterMovimentosTipoVenda();
        List<MovimentoDTO> ObterMovimentosTipoAusencia();
        MovimentoDTO ObterMovimentoPorId(string idMovimento);
        void AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew);
        void ExcluirMovimento(string idMovimento);
    }
}