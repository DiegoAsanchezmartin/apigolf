using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi83.Services.IServices
{
    public interface IClienteService
    {
        Task<Response<List<Cliente>>> ObtenerClientes();
        Task<Response<Cliente>> ObtenerClientePorId(int id);
        Task<Response<Cliente>> CrearCliente(ClienteDTO clienteDTO);
        Task<Response<Cliente>> ActualizarCliente(int id, ClienteDTO clienteDTO);
        Task<Response<Cliente>> EliminarCliente(int id);
    }
}
