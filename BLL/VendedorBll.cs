using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class VendedorBll : IVendedorBll
    {
        public string Mensagem = "Mensagem";

        public readonly IVendedorDAO _vendedorDAO;
        public VendedorBll(IVendedorDAO vendedorDAO)
        {
            _vendedorDAO = vendedorDAO;
        }

        public List<VendedorDTO> ObterTodosVendedores()
        {
            var verifica = _vendedorDAO.ObterTodosVendedores();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosVendedores() BLL executado corretamente";
            
            return verifica;
        }

        public List<VendedorDTO> ObterVendedorEmEspera()
        {
            var verifica = _vendedorDAO.ObterVendedorEmEspera();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedorEmEspera() BLL executado corretamente";
            
            return verifica;
        }

        public List<VendedorDTO> ObterVendedorEmAtendimento()
        {
            var verifica = _vendedorDAO.ObterVendedorEmAtendimento();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedorEmAtendimento() BLL executado corretamente";
            
            return verifica;
        }

        public List<VendedorDTO> ObterVendedorEmAusencia()
        {
            var verifica = _vendedorDAO.ObterVendedorEmAusencia();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterVendedorEmAusencia() BLL executado corretamente";
            
            return verifica;
        }

        public VendedorDTO ObterVendedorPorId(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
               return _vendedorDAO.ObterVendedorPorId(idVendedor); 
            }  
            return null;
        }

        public VendedorDTO ObterVendedorPorCodigo(string codigoVendedor)
        {
            if((codigoVendedor != null)&&(codigoVendedor != ""))
            {
               return _vendedorDAO.ObterVendedorPorCodigo(codigoVendedor); 
            }  
            return null;
        }

        public VendedorDTO ObterVendedorPorNome(string nomeVendedor)
        {
            if((nomeVendedor != null)&&(nomeVendedor != ""))
            {
               return _vendedorDAO.ObterVendedorPorNome(nomeVendedor); 
            }          
            return null;
        }

        public void AdicionarNovoVendedor(VendedorDTO vendedor)
        {
            if((vendedor != null)&&(vendedor.NomeVendedor != null))
            {
                _vendedorDAO.AdicionarNovoVendedor(vendedor);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovoVendedor() BLL";
        }

        public void AtualizarVendedor(string idVendedor, VendedorDTO vendedorNew)
        {
            if((idVendedor != null)&&(vendedorNew != null))
            {
                _vendedorDAO.AtualizarVendedor(idVendedor, vendedorNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarVendedor() BLL";
        }

        public void ExcluirVendedor(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
                _vendedorDAO.ExcluirVendedor(idVendedor);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}