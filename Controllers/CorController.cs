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
    
    public class CorController : ControllerBase
    {
        private readonly ICorBll _corBll;
        public CorController(ICorBll corBll)
        {
            _corBll = corBll;
        }

        [HttpGet("ObterTodasCores")]
        public ActionResult<List<Cor>> ObterTodasCores()
        {
            try
            {
                return Ok(_corBll.ObterTodasCores());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterCorPorId/{idCor}")]
        public ActionResult<Cor> ObterCorPorId(string idCor)
        {
            try
            {
                return Ok(_corBll.ObterCorPorId(idCor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovaCor")]
        public ActionResult<Cor> AdicionarNovaCor(CorDTO cor)
        {
            try
            {
                _corBll.AdicionarNovaCor(cor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarCor/{idCor}")]
        public IActionResult AtualizarCor(string idCor, CorDTO corNew)
        {
            try
            {
                _corBll.AtualizarCor(idCor, corNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirCor/{idCor}")]
        public IActionResult ExcluirCor(string idCor)
        {
            try
            {
                _corBll.ExcluirCor(idCor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}