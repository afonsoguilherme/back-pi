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
    
    public class TipoController : ControllerBase
    {
        private readonly ITipoBll _tipoBll;
        public TipoController(ITipoBll tipoBll)
        {
            _tipoBll = tipoBll;
        }

        [HttpGet("ObterTodosTipos")]
        public ActionResult<List<Tipo>> ObterTodosTipos()
        {
            try
            {
                return Ok(_tipoBll.ObterTodosTipos());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterTipoPorId/{idTipo}")]
        public ActionResult<Tipo> ObterTipoPorId(string idTipo)
        {
            try
            {
                return Ok(_tipoBll.ObterTipoPorId(idTipo));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovoTipo")]
        public ActionResult<Tipo> AdicionarNovoTipo(TipoDTO tipo)
        {
            try
            {
                _tipoBll.AdicionarNovoTipo(tipo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarTipo/{idTipo}")]
        public IActionResult AtualizarTipo(string idTipo, TipoDTO tipoNew)
        {
            try
            {
                _tipoBll.AtualizarTipo(idTipo, tipoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirTipo/{idTipo}")]
        public IActionResult ExcluirTipo(string idTipo)
        {
            try
            {
                _tipoBll.ExcluirTipo(idTipo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}