using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using back_pi.BLL;
using back_pi.DAL.Models;

namespace back_pi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class FilaAusenciaController : ControllerBase
    {
        private readonly IFilaAusenciaBll _FilaAusenciaBll;
        public FilaAusenciaController(IFilaAusenciaBll FilaAusenciaBll)
        {
            _FilaAusenciaBll = FilaAusenciaBll;
        }

        [HttpGet("ObterVendedoresFilaAusencia")]
        public ActionResult<List<FilaAusencia>> ObterVendedoresFilaAusencia()
        {
            try
            {
                return Ok(_FilaAusenciaBll.ObterVendedoresFilaAusencia());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        } 

        [HttpPost("FinalizarAusencia/{idVendedor}")]
        public IActionResult FinalizarAusencia(string idVendedor)
        {
            try
            {
                _FilaAusenciaBll.FinalizarAusencia(idVendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }     
    }
}