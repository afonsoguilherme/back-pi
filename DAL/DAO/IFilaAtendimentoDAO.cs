using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IFilaAtendimentoDAO
    {
        List<FilaAtendimento> ObterVendedoresFilaAtendimento();
        void FinalizarAtendimento(string idVendedor);
    }
}