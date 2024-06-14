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
    public class RentaController : ControllerBase
    {
        private readonly IRentaService _rentaService;

        public RentaController(IRentaService rentaService)
        {
            _rentaService = rentaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRentas()
        {
            try
            {
                var response = await _rentaService.ObtenerRentas();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerRentaPorId(int id)
        {
            try
            {
                var response = await _rentaService.ObtenerRentaPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearRenta([FromBody] RentaDTO rentaDTO)
        {
            try
            {
                var response = await _rentaService.CrearRenta(rentaDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarRenta(int id, [FromBody] RentaDTO rentaDTO)
        {
            try
            {
                var response = await _rentaService.ActualizarRenta(id, rentaDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarRenta(int id)
        {
            try
            {
                var response = await _rentaService.EliminarRenta(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
