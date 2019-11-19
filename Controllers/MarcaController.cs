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
    
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaBll _marcaBll;
        public MarcaController(IMarcaBll marcaBll)
        {
            _marcaBll = marcaBll;
        }

        [HttpGet("ObterTodasMarcas")]
        public ActionResult<List<Marca>> ObterTodasMarcas()
        {
            try
            {
                return Ok(_marcaBll.ObterTodasMarcas());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterMarcaPorId/{idMarca}")]
        public ActionResult<Marca> ObterMarcaPorId(string idMarca)
        {
            try
            {
                return Ok(_marcaBll.ObterMarcaPorId(idMarca));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovaMarca")]
        public ActionResult<Marca> AdicionarNovaMarca(MarcaDTO marca)
        {
            try
            {
                _marcaBll.AdicionarNovaMarca(marca);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarMarca/{idMarca}")]
        public IActionResult AtualizarMarca(string idMarca, MarcaDTO marcaNew)
        {
            try
            {
                _marcaBll.AtualizarMarca(idMarca, marcaNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirMarca/{idMarca}")]
        public IActionResult ExcluirMarca(string idMarca)
        {
            try
            {
                _marcaBll.ExcluirMarca(idMarca);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}