using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class VendaNaoSucedidaBll : IVendaNaoSucedidaBll
    {
        public string Mensagem = "Mensagem";

        public readonly IVendaNaoSucedidaDAO _vendaNaoSucedidaDAO;
        public VendaNaoSucedidaBll(IVendaNaoSucedidaDAO vendaNaoSucedidaDAO)
        {
            _vendaNaoSucedidaDAO = vendaNaoSucedidaDAO;
        }

        public List<VendaNaoSucedidaDTO> ObterTodasVendasNaoSucedidas()
        {
            var verifica = _vendaNaoSucedidaDAO.ObterTodasVendasNaoSucedidas();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosVendaNaoSucedida() BLL executado corretamente";
            
            return verifica;
        }

        public VendaNaoSucedidaDTO ObterVendaNaoSucedidaPorId(string idVendaNaoSucedida)
        {
            if((idVendaNaoSucedida != null)&&(idVendaNaoSucedida != ""))
            {
               return _vendaNaoSucedidaDAO.ObterVendaNaoSucedidaPorId(idVendaNaoSucedida); 
            }  
            return null;
        }

        public void AdicionarNovaVendaNaoSucedida(VendaNaoSucedidaDTO vendaNaoSucedida)
        {
            if((vendaNaoSucedida != null)&&(vendaNaoSucedida.IdMovimento != null))
            {
                _vendaNaoSucedidaDAO.AdicionarNovaVendaNaoSucedida(vendaNaoSucedida);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovaVendaNaoSucedida() BLL";
        }

        public void AtualizarVendaNaoSucedida(string idVendaNaoSucedida, VendaNaoSucedidaDTO vendaNaoSucedidaNew)
        {
            if((idVendaNaoSucedida != null)&&(vendaNaoSucedidaNew != null))
            {
                _vendaNaoSucedidaDAO.AtualizarVendaNaoSucedida(idVendaNaoSucedida, vendaNaoSucedidaNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarVendaNaoSucedidar() BLL";
        }

        public void ExcluirVendaNaoSucedida(string idVendaNaoSucedida)
        {
            if((idVendaNaoSucedida != null)&&(idVendaNaoSucedida != ""))
            {
                _vendaNaoSucedidaDAO.ExcluirVendaNaoSucedida(idVendaNaoSucedida);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}