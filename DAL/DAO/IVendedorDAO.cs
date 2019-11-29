using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface IVendedorDAO
    {
        void AdicionarNovoVendedor(VendedorDTO vendedor);
        List<VendedorDTO> ObterTodosVendedores();
        List<VendedorDTO> ObterVendedorEmEspera();
        List<VendedorDTO> ObterVendedorEmAtendimento();
        List<VendedorDTO> ObterVendedorEmAusencia();
        VendedorDTO ObterVendedorPorId(string idVendedor);
        VendedorDTO ObterVendedorPorNome(string nomeVendedor);
        VendedorDTO ObterVendedorPorCodigo(string codigoVendedor);
        void AtualizarVendedor(string idVendedor, VendedorDTO vendedorNew);
        void ExcluirVendedor(string idVendedor);
    }
}