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
    
    public class VendaNaoSucedidaController : ControllerBase
    {
        private readonly IVendaNaoSucedidaBll _vendaNaoSucedidaBll;
        public VendaNaoSucedidaController(IVendaNaoSucedidaBll vendaNaoSucedidaBll)
        {
            _vendaNaoSucedidaBll = vendaNaoSucedidaBll;
        }

        [HttpGet("ObterTodasVendaNaoSucedida")]
        public ActionResult<List<VendaNaoSucedida>> ObterTodasVendasNaoSucedidas()
        {
            try
            {
                return Ok(_vendaNaoSucedidaBll.ObterTodasVendasNaoSucedidas());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("ObterVendaNaoSucedidaPorId/{idVendaNaoSucedida}")]
        public ActionResult<VendaNaoSucedida> ObterVendaNaoSucedidaPorId(string idVendaNaoSucedida)
        {
            try
            {
                return Ok(_vendaNaoSucedidaBll.ObterVendaNaoSucedidaPorId(idVendaNaoSucedida));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovaVendaNaoSucedida")]
        public ActionResult<VendaNaoSucedida> AdicionarNovaVendaNaoSucedida(VendaNaoSucedidaDTO vendaNaoSucedida)
        {
            try
            {
                _vendaNaoSucedidaBll.AdicionarNovaVendaNaoSucedida(vendaNaoSucedida);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarVendaNaoSucedida/{idVendaNaoSucedida}")]
        public IActionResult AtualizarVendaNaoSucedida(string idVendaNaoSucedida, VendaNaoSucedidaDTO vendaNaoSucedidaNew)
        {
            try
            {
                _vendaNaoSucedidaBll.AtualizarVendaNaoSucedida(idVendaNaoSucedida, vendaNaoSucedidaNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirVendaNaoSucedida/{idVendaNaoSucedida}")]
        public IActionResult ExcluirVendaNaoSucedida(string idVendaNaoSucedida)
        {
            try
            {
                _vendaNaoSucedidaBll.ExcluirVendaNaoSucedida(idVendaNaoSucedida);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}