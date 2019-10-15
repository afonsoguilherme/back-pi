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