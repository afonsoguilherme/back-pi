using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class MovimentoBll : IMovimentoBll
    {
        public string Movimento = "Movimento";

        public readonly IMovimentoDAO _movimentoDAO;
        public MovimentoBll(IMovimentoDAO movimentoDAO)
        {
            _movimentoDAO = movimentoDAO;
        }

        public List<MovimentoDTO> ObterTodosMovimentos()
        {
            var verifica = _movimentoDAO.ObterTodosMovimentos();

            if(verifica == null){ return null; }
            
            this.Movimento = "Metodo ObterTodosMovimentos() BLL executado corretamente";
            
            return verifica;
        }

        public MovimentoDTO ObterMovimentoPorId(string idMovimento)
        {
            if((idMovimento != null)&&(idMovimento != ""))
            {
               return _movimentoDAO.ObterMovimentoPorId(idMovimento); 
            }  
            return null;
        }

        public List<MovimentoDTO> ObterMovimentosPorVendedor(string idVendedor)
        {
            if((idVendedor != null)&&(idVendedor != ""))
            {
               return _movimentoDAO.ObterMovimentosPorVendedor(idVendedor); 
            }  
            return null;
        }

        public void AdicionarNovoMovimento(MovimentoDTO movimento)
        {
            if((movimento != null)&&(movimento.IdVendedor != null))
            {
                _movimentoDAO.AdicionarNovoMovimento(movimento);
            }
            
            this.Movimento = "Falha na execucao do metodo AdicionarNovoMovimento() BLL";
        }

        public void FinalizarMovimento(MovimentoDTO movimento)
        {
            if((movimento != null)&&(movimento.IdVendedor != null))
            {
                _movimentoDAO.FinalizarMovimento(movimento);
            }
            
            this.Movimento = "Falha na execucao do metodo FinalizarMovimento() BLL";
        }

        public void AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew)
        {
            if((idMovimento != null)&&(movimentoNew != null))
            {
                _movimentoDAO.AtualizarMovimento(idMovimento, movimentoNew);
            }
            this.Movimento = "Falha na execucao do metodo AtualizarMovimento() BLL";
        }

        public void ExcluirMovimento(string idMovimento)
        {
            if((idMovimento != null)&&(idMovimento != ""))
            {
                _movimentoDAO.ExcluirMovimento(idMovimento);
            }
            this.Movimento = "Falha na execucao do metodo ExcluirMovimento() BLL";
        }
    }
}