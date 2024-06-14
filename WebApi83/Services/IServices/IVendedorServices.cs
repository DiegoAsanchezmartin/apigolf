using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi83.Services.IServices
{
    public interface IVendedorServices
    {
        public Task<Response<List<Vendedor>>> ObtenerVendedores();
        public Task<Response<Vendedor>> ObtenerVendedorPorId(int id);
        public Task<Response<Vendedor>> CrearVendedor(VendedorDTO vendedorDTO);
        public Task<Response<Vendedor>> ActualizarVendedor(int id, VendedorDTO vendedorDTO);
        public Task<Response<Vendedor>> EliminarVendedor(int id);
    }
}
