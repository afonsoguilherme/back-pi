using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IFilaEsperaDAO
    {
        List<FilaEspera> ObterVendedoresFilaEspera();
        void IniciarAtendimento(string idVendedor);
        void IniciarAusencia(string idVendedor);
    }
}