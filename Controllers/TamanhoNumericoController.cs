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
    
    public class TamanhoNumericoController : ControllerBase
    {
        private readonly ITamanhoNumericoBll _tipoBll;
        public TamanhoNumericoController(ITamanhoNumericoBll tipoBll)
        {
            _tipoBll = tipoBll;
        }

        [HttpGet("ObterTodosTamanhosNumericos")]
        public ActionResult<List<TamanhoNumerico>> ObterTodosTamanhosNumericos()
        {
            try
            {
                return Ok(_tipoBll.ObterTodosTamanhosNumericos());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterTamanhoNumericoPorId/{idTamanhoNumerico}")]
        public ActionResult<TamanhoNumerico> ObterTamanhoNumericoPorId(string idTamanhoNumerico)
        {
            try
            {
                return Ok(_tipoBll.ObterTamanhoNumericoPorId(idTamanhoNumerico));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovoTamanhoNumerico")]
        public ActionResult<TamanhoNumerico> AdicionarNovoTamanhoNumerico(TamanhoNumericoDTO tipo)
        {
            try
            {
                _tipoBll.AdicionarNovoTamanhoNumerico(tipo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarTamanhoNumerico/{idTamanhoNumerico}")]
        public IActionResult AtualizarTamanhoNumerico(string idTamanhoNumerico, TamanhoNumericoDTO tipoNew)
        {
            try
            {
                _tipoBll.AtualizarTamanhoNumerico(idTamanhoNumerico, tipoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirTamanhoNumerico/{idTamanhoNumerico}")]
        public IActionResult ExcluirTamanhoNumerico(string idTamanhoNumerico)
        {
            try
            {
                _tipoBll.ExcluirTamanhoNumerico(idTamanhoNumerico);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}