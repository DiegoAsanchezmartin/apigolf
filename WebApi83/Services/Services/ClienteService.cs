using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi83.Context;
using WebApi83.Services.IServices;

namespace WebApi83.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AplicationDBcontext _context;

        public ClienteService(AplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<Response<List<Cliente>>> ObtenerClientes()
        {
            try
            {
                List<Cliente> clientes = await _context.Clientes.ToListAsync();
                return new Response<List<Cliente>>(clientes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> ObtenerClientePorId(int id)
        {
            try
            {
                Cliente cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return new Response<Cliente>("No se encontró ningún cliente con el ID proporcionado.");
                }

                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> CrearCliente(ClienteDTO clienteDTO)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    Nombre = clienteDTO.Nombre,
                    Email = clienteDTO.Email,
                    Telefono = clienteDTO.Telefono
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el cliente: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> ActualizarCliente(int id, ClienteDTO clienteDTO)
        {
            try
            {
                Cliente cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return new Response<Cliente>("No se encontró ningún cliente con el ID proporcionado.");
                }

                cliente.Nombre = clienteDTO.Nombre;
                cliente.Email = clienteDTO.Email;
                cliente.Telefono = clienteDTO.Telefono;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> EliminarCliente(int id)
        {
            try
            {
                Cliente cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return new Response<Cliente>("No se encontró ningún cliente con el ID proporcionado.");
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message);
            }
        }
    }
}
