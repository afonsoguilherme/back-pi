using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using back_sistema_tg.BLL;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.Utils;
using back_sistema_tg.BLL.Exceptions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using back_sistema_tg.DAL.Models;
using back_sistema_tg.Extensions.Responses;
using AutoMapper;

namespace back_sistema_tg.Controllers
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