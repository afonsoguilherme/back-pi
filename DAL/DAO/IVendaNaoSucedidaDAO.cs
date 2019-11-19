using System.Collections.Generic;
using back_pi.DAL.DTO;

namespace back_pi.DAL.DAO
{
    public interface IVendaNaoSucedidaDAO
    {
        void AdicionarNovaVendaNaoSucedida(VendaNaoSucedidaDTO vendaNaoSucedida);
        List<VendaNaoSucedidaDTO> ObterTodasVendasNaoSucedidas();
        VendaNaoSucedidaDTO ObterVendaNaoSucedidaPorId(string idVendaNaoSucedida);
        void AtualizarVendaNaoSucedida(string idVendaNaoSucedida, VendaNaoSucedidaDTO vendaNaoSucedidaNew);
        void ExcluirVendaNaoSucedida(string idVendaNaoSucedida);
    }
}