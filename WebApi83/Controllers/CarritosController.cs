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
    public class CarritosController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritosController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCarritos()
        {
            try
            {
                var response = await _carritoService.ObtenerCarritos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerCarritoPorId(int id)
        {
            try
            {
                var response = await _carritoService.ObtenerCarritoPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearCarrito([FromBody] CarritosDTO carritoDTO)
        {
            try
            {
                var response = await _carritoService.CrearCarrito(carritoDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarCarrito(int id, [FromBody] CarritosDTO carritoDTO)
        {
            try
            {
                var response = await _carritoService.ActualizarCarrito(id, carritoDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarCarrito(int id)
        {
            try
            {
                var response = await _carritoService.EliminarCarrito(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("disponibles")]
        public async Task<IActionResult> Disponibles()
        {
            try
            {
                var response = await _carritoService.CDisponibles();
                return Ok(response);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        

        [HttpGet("rentados")]

        public async Task<IActionResult> Rentados()
        {
            try
            {
                var response = await _carritoService.CRentados();
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }





    }


}
