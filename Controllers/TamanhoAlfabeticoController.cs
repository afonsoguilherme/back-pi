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
    
    public class TamanhoController : ControllerBase
    {
        private readonly ITamanhoBll _tipoBll;
        public TamanhoController(ITamanhoBll tipoBll)
        {
            _tipoBll = tipoBll;
        }

        [HttpGet("ObterTodosTamanhos")]
        public ActionResult<List<Tamanho>> ObterTodosTamanhoss()
        {
            try
            {
                return Ok(_tipoBll.ObterTodosTamanhoss());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterTamanhoPorId/{idTamanho}")]
        public ActionResult<Tamanho> ObterTamanhoPorId(string idTamanho)
        {
            try
            {
                return Ok(_tipoBll.ObterTamanhoPorId(idTamanho));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovoTamanho")]
        public ActionResult<Tamanho> AdicionarNovoTamanho(TamanhoDTO tipo)
        {
            try
            {
                _tipoBll.AdicionarNovoTamanho(tipo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarTamanho/{idTamanho}")]
        public IActionResult AtualizarTamanho(string idTamanho, TamanhoDTO tipoNew)
        {
            try
            {
                _tipoBll.AtualizarTamanho(idTamanho, tipoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirTamanho/{idTamanho}")]
        public IActionResult ExcluirTamanho(string idTamanho)
        {
            try
            {
                _tipoBll.ExcluirTamanho(idTamanho);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}