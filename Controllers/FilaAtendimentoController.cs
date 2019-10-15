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
    
    public class FilaAtendimentoController : ControllerBase
    {
        private readonly IFilaAtendimentoBll _FilaAtendimentoBll;
        public FilaAtendimentoController(IFilaAtendimentoBll FilaAtendimentoBll)
        {
            _FilaAtendimentoBll = FilaAtendimentoBll;
        }

        [HttpGet("ObterVendedoresFilaAtendimento")]
        public ActionResult<List<FilaAtendimento>> ObterVendedoresFilaAtendimento()
        {
            try
            {
                return Ok(_FilaAtendimentoBll.ObterVendedoresFilaAtendimento());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }      

        [HttpPost("FinalizarAtendimento/{idVendedor}")]
        public IActionResult FinalizarAtendimento(string idVendedor)
        {
            try
            {
                _FilaAtendimentoBll.FinalizarAtendimento(idVendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}