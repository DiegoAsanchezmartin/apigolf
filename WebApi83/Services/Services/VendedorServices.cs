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
    public class VendedorServices : IVendedorServices
    {
        private readonly AplicationDBcontext _context;

        public VendedorServices(AplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<Response<List<Vendedor>>> ObtenerVendedores()
        {
            try
            {
                List<Vendedor> vendedores = await _context.Vendedores.ToListAsync();

                return new Response<List<Vendedor>>(vendedores);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener vendedores: " + ex.Message);
            }
        }

        public async Task<Response<Vendedor>> ObtenerVendedorPorId(int id)
        {
            try
            {
                Vendedor vendedor = await _context.Vendedores.FindAsync(id);

                if (vendedor == null)
                {
                    return new Response<Vendedor>("No se encontró ningún vendedor con el ID proporcionado.");
                }

                return new Response<Vendedor>(vendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vendedor: " + ex.Message);
            }
        }

        public async Task<Response<Vendedor>> CrearVendedor(VendedorDTO vendedorDTO)
        {
            try
            {
                Vendedor vendedor = new Vendedor
                {
                    Nombre = vendedorDTO.Nombre,
                    IMGPerfil = vendedorDTO.IMGPerfil,
                    Email = vendedorDTO.Email,
                    Password = vendedorDTO.Password,
                    Telefono = vendedorDTO.Telefono
                };

                _context.Vendedores.Add(vendedor);
                await _context.SaveChangesAsync();

                return new Response<Vendedor>(vendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el vendedor: " + ex.Message);
            }
        }

        public async Task<Response<Vendedor>> ActualizarVendedor(int id, VendedorDTO vendedorDTO)
        {
            try
            {
                Vendedor vendedor = await _context.Vendedores.FindAsync(id);

                if (vendedor == null)
                {
                    return new Response<Vendedor>("No se encontró ningún vendedor con el ID proporcionado.");
                }

                vendedor.Nombre = vendedorDTO.Nombre;
                vendedor.IMGPerfil = vendedorDTO.IMGPerfil;
                vendedor.Email = vendedorDTO.Email;
                vendedor.Password = vendedorDTO.Password;
                vendedor.Telefono = vendedorDTO.Telefono;

                _context.Entry(vendedor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Vendedor>(vendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el vendedor: " + ex.Message);
            }
        }

        public async Task<Response<Vendedor>> EliminarVendedor(int id)
        {
            try
            {
                Vendedor vendedor = await _context.Vendedores.FindAsync(id);

                if (vendedor == null)
                {
                    return new Response<Vendedor>("No se encontró ningún vendedor con el ID proporcionado.");
                }

                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();

                return new Response<Vendedor>(vendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el vendedor: " + ex.Message);
            }
        }
    }
}
