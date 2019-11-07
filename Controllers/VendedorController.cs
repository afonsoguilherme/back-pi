using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using back_pi.BLL;
using back_pi.DAL.DTO;
using back_pi.Utils;
using back_pi.BLL.Exceptions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using back_pi.DAL.Models;
using back_pi.Extensions.Responses;
using AutoMapper;

namespace back_pi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorBll _vendedorBll;
        public VendedorController(IVendedorBll vendedorBll)
        {
            _vendedorBll = vendedorBll;
        }

        [HttpGet("ObterTodosVendedores")]
        public ActionResult<List<Vendedor>> ObterTodosVendedores()
        {
            try
            {
                return Ok(_vendedorBll.ObterTodosVendedores());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterVendedorPorId/{idVendedor}")]
        public ActionResult<Vendedor> ObterVendedorPorId(string idVendedor)
        {
            try
            {
                return Ok(_vendedorBll.ObterVendedorPorId(idVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterVendedorPorCodigo/{codigoVendedor}")]
        public ActionResult<Vendedor> ObterVendedorPorCodigo(string codigoVendedor)
        {
            try
            {
                return Ok(_vendedorBll.ObterVendedorPorCodigo(codigoVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ObterVendedorPorNome/{nomeVendedor}")]
        public ActionResult<Vendedor> ObterVendedorPorNome(string nomeVendedor)
        {
            try
            {
                return Ok(_vendedorBll.ObterVendedorPorNome(nomeVendedor));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost("AdicionarNovoVendedor")]
        public ActionResult<Vendedor> AdicionarNovoVendedor(VendedorDTO vendedor)
        {
            try
            {
                _vendedorBll.AdicionarNovoVendedor(vendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("AtualizarVendedor/{idVendedor}")]
        public IActionResult AtualizarVendedor(string idVendedor, VendedorDTO vendedorNew)
        {
            try
            {
                _vendedorBll.AtualizarVendedor(idVendedor, vendedorNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ExcluirVendedor/{idVendedor}")]
        public IActionResult ExcluirVendedor(string idVendedor)
        {
            try
            {
                _vendedorBll.ExcluirVendedor(idVendedor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}