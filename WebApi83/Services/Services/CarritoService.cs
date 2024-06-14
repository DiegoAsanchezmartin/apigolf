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
    public class CarritoService : ICarritoService
    {
        private readonly AplicationDBcontext _context;

        public CarritoService(AplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<Response<List<Carritos>>> ObtenerCarritos()
        {
            try
            {
                List<Carritos> carritos = await _context.Carritos.ToListAsync();

                return new Response<List<Carritos>>(carritos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener carritos: " + ex.Message);
            }
        }

        public async Task<Response<Carritos>> ObtenerCarritoPorId(int id)
        {
            try
            {
                Carritos carrito = await _context.Carritos.FindAsync(id);

                if (carrito == null)
                {
                    return new Response<Carritos>("No se encontró ningún carrito con el ID proporcionado.");
                }

                return new Response<Carritos>(carrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el carrito: " + ex.Message);
            }
        }

        public async Task<Response<Carritos>> CrearCarrito(CarritosDTO carritoDTO)
        {
            try
            {
                Carritos carrito = new Carritos
                {
                    Modelo = carritoDTO.Modelo,
                    Marca = carritoDTO.Marca,
                    PrecioHora = carritoDTO.PrecioHora,
                    IMGURL = carritoDTO.IMGURL,
                    Enrenta = carritoDTO.Enrenta
                };

                _context.Carritos.Add(carrito);
                await _context.SaveChangesAsync();

                return new Response<Carritos>(carrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el carrito: " + ex.Message);
            }
        }

        public async Task<Response<Carritos>> ActualizarCarrito(int id, CarritosDTO carritoDTO)
        {
            try
            {
                Carritos carrito = await _context.Carritos.FindAsync(id);

                if (carrito == null)
                {
                    return new Response<Carritos>("No se encontró ningún carrito con el ID proporcionado.");
                }

                carrito.Modelo = carritoDTO.Modelo;
                carrito.Marca = carritoDTO.Marca;
                carrito.PrecioHora = carritoDTO.PrecioHora;
                carrito.IMGURL = carritoDTO.IMGURL;
                carrito.Enrenta = carritoDTO.Enrenta;

                _context.Entry(carrito).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Carritos>(carrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el carrito: " + ex.Message);
            }
        }

        public async Task<Response<Carritos>> EliminarCarrito(int id)
        {
            try
            {
                Carritos carrito = await _context.Carritos.FindAsync(id);

                if (carrito == null)
                {
                    return new Response<Carritos>("No se encontró ningún carrito con el ID proporcionado.");
                }

                _context.Carritos.Remove(carrito);
                await _context.SaveChangesAsync();

                return new Response<Carritos>(carrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el carrito: " + ex.Message);
            }
        }


        public async Task<Response<List<Carritos>>> CDisponibles()
        {
            try
            {
                List<Carritos> carritosDisponibles = await _context.Carritos
                    .Where(c => c.Enrenta == false)
                    .ToListAsync();

                return new Response<List<Carritos>>(carritosDisponibles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los carritos disponibles: " + ex.Message);
            }
        }

        public async Task<Response<List<Carritos>>> CRentados()
        {
            try
            {
                List<Carritos> carritosRentados = await _context.Carritos
                    .Where(c => c.Enrenta == true)
                    .ToListAsync();

                return new Response<List<Carritos>>(carritosRentados);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los carritos rentados: " + ex.Message);
            }
        }























    }
}
