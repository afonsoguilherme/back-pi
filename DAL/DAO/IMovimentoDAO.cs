using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IMovimentoDAO
    {
        void AdicionarNovoMovimento(MovimentoDTO movimento);
        void FinalizarMovimento(MovimentoDTO movimento);
        List<MovimentoDTO> ObterTodosMovimentos();
        List<MovimentoDTO> ObterMovimentosPorVendedor(string idVendedor);
        MovimentoDTO ObterMovimentoPorId(string idMovimento);
        void AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew);
        void ExcluirMovimento(string idMovimento);
    }
}