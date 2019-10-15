using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IVendedorBll
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