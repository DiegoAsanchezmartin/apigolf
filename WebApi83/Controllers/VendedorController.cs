using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi83.Services.IServices;

namespace WebApi83.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorServices _vendedorServices;

        public VendedorController(IVendedorServices vendedorServices)
        {
            _vendedorServices = vendedorServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerVendedores()
        {
            try
            {
                var response = await _vendedorServices.ObtenerVendedores();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerVendedorPorId(int id)
        {
            try
            {
                var response = await _vendedorServices.ObtenerVendedorPorId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearVendedor([FromBody] VendedorDTO vendedorDTO)
        {
            try
            {
                var response = await _vendedorServices.CrearVendedor(vendedorDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarVendedor(int id, [FromBody] VendedorDTO vendedorDTO)
        {
            try
            {
                var response = await _vendedorServices.ActualizarVendedor(id, vendedorDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarVendedor(int id)
        {
            try
            {
                var response = await _vendedorServices.EliminarVendedor(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

