using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using back_pi.BLL;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class MovimentoController : ControllerBase
    {
        // INJEÇÃO DE DEPENDENCIAS
        private readonly IMovimentoBll _movimentoBll;
        public MovimentoController(IMovimentoBll movimentoBll)
        {
            _movimentoBll = movimentoBll;
        }
 
        [HttpGet("ObterTodosMovimentos")]
        public ActionResult<List<Movimento>> ObterTodosMovimentos()
        {
            try
            {
                return Ok(_movimentoBll.ObterTodosMovimentos());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterGraficoInd/{idVendedor}")]
        public ActionResult ObterGraficoInd(string idVendedor)
        {
            try
            {
                return Ok(_movimentoBll.ObterGraficoInd(idVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterGrafico")]
        public ActionResult ObterGrafico()
        {
            try
            {
                return Ok(_movimentoBll.ObterGrafico());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("MovimentosVendedores")]
        public ActionResult<List<Movimento>> MovimentosVendedores()
        {
            try
            {
                return Ok(_movimentoBll.MovimentosVendedores());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("MovimentosVendedoresNãoSucedido")]
        public ActionResult<List<Movimento>> MovimentosVendedoresNãoSucedido()
        {
            try
            {
                return Ok(_movimentoBll.MovimentosVendedoresNãoSucedido());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("ObterMovimentoPorId/{idMovimento}")]
        public ActionResult<Movimento> ObterMovimentoPorId(string idMovimento)
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentoPorId(idMovimento));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterMovimentoPorVendedor/{idVendedor}")]
        public ActionResult<List<Movimento>> ObterMovimentoPorVendedor(string idVendedor)
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentosPorVendedor(idVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
       
        [HttpGet("ObterMovimentosTipoVenda")]
        public ActionResult<List<Movimento>> ObterMovimentosTipoVenda()
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentosTipoVenda());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterMovimentosTipoAusencia")]
        public ActionResult<List<Movimento>> ObterMovimentosTipoAusencia()
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentosTipoAusencia());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("AdicionarNovoMovimento")]
        public ActionResult<Movimento> AdicionarNovoMovimento(MovimentoDTO movimento)
        {
            try
            {
                _movimentoBll.AdicionarNovoMovimento(movimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("FinalizarMovimento")]
        public ActionResult<Movimento> FinalizarMovimento(MovimentoDTO movimento)
        {
            try
            {
                _movimentoBll.FinalizarMovimento(movimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarMovimento/{idMovimento}")]
        public IActionResult AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew)
        {
            try
            {
                _movimentoBll.AtualizarMovimento(idMovimento, movimentoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirMovimento/{idMovimento}")]
        public IActionResult ExcluirMovimento(string idMovimento)
        {
            try
            {
                _movimentoBll.ExcluirMovimento(idMovimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}