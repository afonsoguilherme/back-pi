using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IFilaAusenciaDAO
    {
        List<FilaAusencia> ObterVendedoresFilaAusencia();
        void FinalizarAusencia(string idVendedor);
    }
}