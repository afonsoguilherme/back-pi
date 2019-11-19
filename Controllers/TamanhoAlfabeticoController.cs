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
    
    public class TamanhoAlfabeticoController : ControllerBase
    {
        private readonly ITamanhoAlfabeticoBll _tipoBll;
        public TamanhoAlfabeticoController(ITamanhoAlfabeticoBll tipoBll)
        {
            _tipoBll = tipoBll;
        }

        [HttpGet("ObterTodosTamanhosAlfabeticos")]
        public ActionResult<List<TamanhoAlfabetico>> ObterTodosTamanhosAlfabeticos()
        {
            try
            {
                return Ok(_tipoBll.ObterTodosTamanhosAlfabeticos());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterTamanhoAlfabeticoPorId/{idTamanhoAlfabetico}")]
        public ActionResult<TamanhoAlfabetico> ObterTamanhoAlfabeticoPorId(string idTamanhoAlfabetico)
        {
            try
            {
                return Ok(_tipoBll.ObterTamanhoAlfabeticoPorId(idTamanhoAlfabetico));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovoTamanhoAlfabetico")]
        public ActionResult<TamanhoAlfabetico> AdicionarNovoTamanhoAlfabetico(TamanhoAlfabeticoDTO tipo)
        {
            try
            {
                _tipoBll.AdicionarNovoTamanhoAlfabetico(tipo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarTamanhoAlfabetico/{idTamanhoAlfabetico}")]
        public IActionResult AtualizarTamanhoAlfabetico(string idTamanhoAlfabetico, TamanhoAlfabeticoDTO tipoNew)
        {
            try
            {
                _tipoBll.AtualizarTamanhoAlfabetico(idTamanhoAlfabetico, tipoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirTamanhoAlfabetico/{idTamanhoAlfabetico}")]
        public IActionResult ExcluirTamanhoAlfabetico(string idTamanhoAlfabetico)
        {
            try
            {
                _tipoBll.ExcluirTamanhoAlfabetico(idTamanhoAlfabetico);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}