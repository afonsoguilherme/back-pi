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
    
    public class MovimentoController : ControllerBase
    {
        // INJEÇÃO DE DEPENDENCIAS
        private readonly IMovimentoBll _movimentoBll;
        public MovimentoController(IMovimentoBll movimentoBll)
        {
            _movimentoBll = movimentoBll;
        }
 
        [HttpGet("ObterTodosMovimentos")]
        public ActionResult<List<Movimento>> ObterTodosMovimentos()
        {
            try
            {
                return Ok(_movimentoBll.ObterTodosMovimentos());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("ObterMovimentoPorId/{idMovimento}")]
        public ActionResult<Movimento> ObterMovimentoPorId(string idMovimento)
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentoPorId(idMovimento));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterMovimentoPorVendedor/{idVendedor}")]
        public ActionResult<List<Movimento>> ObterMovimentoPorVendedor(string idVendedor)
        {
            try
            {
                return Ok(_movimentoBll.ObterMovimentosPorVendedor(idVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
       
        [HttpPost("AdicionarNovoMovimento")]
        public ActionResult<Movimento> AdicionarNovoMovimento(MovimentoDTO movimento)
        {
            try
            {
                _movimentoBll.AdicionarNovoMovimento(movimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("FinalizarMovimento")]
        public ActionResult<Movimento> FinalizarMovimento(MovimentoDTO movimento)
        {
            try
            {
                _movimentoBll.FinalizarMovimento(movimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarMovimento/{idMovimento}")]
        public IActionResult AtualizarMovimento(string idMovimento, MovimentoDTO movimentoNew)
        {
            try
            {
                _movimentoBll.AtualizarMovimento(idMovimento, movimentoNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirMovimento/{idMovimento}")]
        public IActionResult ExcluirMovimento(string idMovimento)
        {
            try
            {
                _movimentoBll.ExcluirMovimento(idMovimento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}