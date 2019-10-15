using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
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