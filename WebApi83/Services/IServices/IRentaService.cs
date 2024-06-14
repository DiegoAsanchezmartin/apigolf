using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi83.Services.IServices
{
    public interface IRentaService
    {
        Task<Response<List<Renta>>> ObtenerRentas();
        Task<Response<Renta>> ObtenerRentaPorId(int id);
        Task<Response<Renta>> CrearRenta(RentaDTO rentaDTO);
        Task<Response<Renta>> ActualizarRenta(int id, RentaDTO rentaDTO);
        Task<Response<Renta>> EliminarRenta(int id);
    }
}
