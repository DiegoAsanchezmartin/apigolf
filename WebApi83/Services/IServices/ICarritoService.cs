using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi83.Services.IServices
{
    public interface ICarritoService
    {
        Task<Response<List<Carritos>>> ObtenerCarritos();
        Task<Response<Carritos>> ObtenerCarritoPorId(int id);
        Task<Response<Carritos>> CrearCarrito(CarritosDTO carritoDTO);
        Task<Response<Carritos>> ActualizarCarrito(int id, CarritosDTO carritoDTO);
        Task<Response<Carritos>> EliminarCarrito(int id);
        Task<Response<List<Carritos>>> CDisponibles();
        Task<Response<List<Carritos>>> CRentados();
    }
}

