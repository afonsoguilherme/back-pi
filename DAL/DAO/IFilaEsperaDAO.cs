using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IFilaEsperaDAO
    {
        List<FilaEspera> ObterVendedoresFilaEspera();
        void IniciarAtendimento(string idVendedor);
        void IniciarAusencia(string idVendedor);
    }
}