using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using back_pi.BLL;
using back_pi.DAL.Models;

namespace back_pi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class FilaEsperaController : ControllerBase
    {
        private readonly IFilaEsperaBll _FilaEsperaBll;
        public FilaEsperaController(IFilaEsperaBll FilaEsperaBll)
        {
            _FilaEsperaBll = FilaEsperaBll;
        }

        [HttpGet("ObterVendedoresFilaEspera")]
        public ActionResult<List<FilaEspera>> ObterVendedoresFilaEspera()
        {
            try
            {
                return Ok(_FilaEsperaBll.ObterVendedoresFilaEspera());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }       

        [HttpPost("IniciarAtendimento/{idVendedor}")]
        public IActionResult IniciarAtendimento(string idVendedor)
        {
            try
            {
                _FilaEsperaBll.IniciarAtendimento(idVendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("IniciarAusencia/{idVendedor}")]
        public IActionResult IniciarAusencia(string idVendedor)
        {
            try
            {
                _FilaEsperaBll.IniciarAusencia(idVendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}