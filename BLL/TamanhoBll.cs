using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class TamanhoBll : ITamanhoBll
    {
        public string Mensagem = "Mensagem";

        public readonly ITamanhoDAO _tamanhoDAO;
        public TamanhoBll(ITamanhoDAO tamanhoDAO)
        {
            _tamanhoDAO = tamanhoDAO;
        }

        public List<TamanhoDTO> ObterTodosTamanhoss()
        {
            var verifica = _tamanhoDAO.ObterTodosTamanhoss();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosTamanhoss() BLL executado tamanhoretamente";
            
            return verifica;
        }

        public TamanhoDTO ObterTamanhoPorId(string idTamanho)
        {
            if((idTamanho != null)&&(idTamanho != ""))
            {
               return _tamanhoDAO.ObterTamanhoPorId(idTamanho); 
            }  
            return null;
        }

        public void AdicionarNovoTamanho(TamanhoDTO tamanho)
        {
            if((tamanho != null)&&(tamanho.DescricaoTamanho != null))
            {
                _tamanhoDAO.AdicionarNovoTamanho(tamanho);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovoTamanho() BLL";
        }

        public void AtualizarTamanho(string idTamanho, TamanhoDTO tamanhoNew)
        {
            if((idTamanho != null)&&(tamanhoNew != null))
            {
                _tamanhoDAO.AtualizarTamanho(idTamanho, tamanhoNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarTamanho() BLL";
        }

        public void ExcluirTamanho(string idTamanho)
        {
            if((idTamanho != null)&&(idTamanho != ""))
            {
                _tamanhoDAO.ExcluirTamanho(idTamanho);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}