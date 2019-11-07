using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IVendedorDAO
    {
        void AdicionarNovoVendedor(VendedorDTO vendedor);
        List<VendedorDTO> ObterTodosVendedores();
        VendedorDTO ObterVendedorPorId(string idVendedor);
        VendedorDTO ObterVendedorPorNome(string nomeVendedor);
        VendedorDTO ObterVendedorPorCodigo(string codigoVendedor);
        void AtualizarVendedor(string idVendedor, VendedorDTO vendedorNew);
        void ExcluirVendedor(string idVendedor);
    }
}