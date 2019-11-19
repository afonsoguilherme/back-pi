using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class MarcaBll : IMarcaBll
    {
        public string Mensagem = "Mensagem";

        public readonly IMarcaDAO _marcaDAO;
        public MarcaBll(IMarcaDAO marcaDAO)
        {
            _marcaDAO = marcaDAO;
        }

        public List<MarcaDTO> ObterTodasMarcas()
        {
            var verifica = _marcaDAO.ObterTodasMarcas();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodasMarcas() BLL executado marcaretamente";
            
            return verifica;
        }

        public MarcaDTO ObterMarcaPorId(string idMarca)
        {
            if((idMarca != null)&&(idMarca != ""))
            {
               return _marcaDAO.ObterMarcaPorId(idMarca); 
            }  
            return null;
        }

        public void AdicionarNovaMarca(MarcaDTO marca)
        {
            if((marca != null)&&(marca.DescricaoMarca != null))
            {
                _marcaDAO.AdicionarNovaMarca(marca);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovaMarca() BLL";
        }

        public void AtualizarMarca(string idMarca, MarcaDTO marcaNew)
        {
            if((idMarca != null)&&(marcaNew != null))
            {
                _marcaDAO.AtualizarMarca(idMarca, marcaNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarMarca() BLL";
        }

        public void ExcluirMarca(string idMarca)
        {
            if((idMarca != null)&&(idMarca != ""))
            {
                _marcaDAO.ExcluirMarca(idMarca);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}