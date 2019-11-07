using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IVendaNaoSucedidaBll
    {
        void AdicionarNovaVendaNaoSucedida(VendaNaoSucedidaDTO vendaNaoSucedida);
        List<VendaNaoSucedidaDTO> ObterTodasVendasNaoSucedidas();
        VendaNaoSucedidaDTO ObterVendaNaoSucedidaPorId(string idVendaNaoSucedida);
        void AtualizarVendaNaoSucedida(string idVendaNaoSucedida, VendaNaoSucedidaDTO vendaNaoSucedidaNew);
        void ExcluirVendaNaoSucedida(string idVendaNaoSucedida);
    }
}