using System.Collections.Generic;
using back_pi.DAL.DAO;
using back_pi.DAL.DTO;

namespace back_pi.BLL
{
    public class TamanhoAlfabeticoBll : ITamanhoAlfabeticoBll
    {
        public string Mensagem = "Mensagem";

        public readonly ITamanhoAlfabeticoDAO _tamanhoAlfabeticoDAO;
        public TamanhoAlfabeticoBll(ITamanhoAlfabeticoDAO tamanhoAlfabeticoDAO)
        {
            _tamanhoAlfabeticoDAO = tamanhoAlfabeticoDAO;
        }

        public List<TamanhoAlfabeticoDTO> ObterTodosTamanhosAlfabeticos()
        {
            var verifica = _tamanhoAlfabeticoDAO.ObterTodosTamanhosAlfabeticos();

            if(verifica == null){ return null; }
            
            this.Mensagem = "Metodo ObterTodosTamanhosAlfabeticos() BLL executado tamanhoAlfabeticoretamente";
            
            return verifica;
        }

        public TamanhoAlfabeticoDTO ObterTamanhoAlfabeticoPorId(string idTamanhoAlfabetico)
        {
            if((idTamanhoAlfabetico != null)&&(idTamanhoAlfabetico != ""))
            {
               return _tamanhoAlfabeticoDAO.ObterTamanhoAlfabeticoPorId(idTamanhoAlfabetico); 
            }  
            return null;
        }

        public void AdicionarNovoTamanhoAlfabetico(TamanhoAlfabeticoDTO tamanhoAlfabetico)
        {
            if((tamanhoAlfabetico != null)&&(tamanhoAlfabetico.DescricaoTamanhoAlfabetico != null))
            {
                _tamanhoAlfabeticoDAO.AdicionarNovoTamanhoAlfabetico(tamanhoAlfabetico);
            }
            
            this.Mensagem = "Falha na execucao do metodo AdicionarNovoTamanhoAlfabetico() BLL";
        }

        public void AtualizarTamanhoAlfabetico(string idTamanhoAlfabetico, TamanhoAlfabeticoDTO tamanhoAlfabeticoNew)
        {
            if((idTamanhoAlfabetico != null)&&(tamanhoAlfabeticoNew != null))
            {
                _tamanhoAlfabeticoDAO.AtualizarTamanhoAlfabetico(idTamanhoAlfabetico, tamanhoAlfabeticoNew);
            }
            this.Mensagem = "Falha na execucao do metodo AtualizarTamanhoAlfabetico() BLL";
        }

        public void ExcluirTamanhoAlfabetico(string idTamanhoAlfabetico)
        {
            if((idTamanhoAlfabetico != null)&&(idTamanhoAlfabetico != ""))
            {
                _tamanhoAlfabeticoDAO.ExcluirTamanhoAlfabetico(idTamanhoAlfabetico);
            }
            this.Mensagem = "Falha na execucao do metodo Excluir() BLL";
        }
    }
}