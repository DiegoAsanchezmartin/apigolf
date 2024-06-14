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
    public class RentaService : IRentaService
    {
        private readonly AplicationDBcontext _context;

        public RentaService(AplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<Response<List<Renta>>> ObtenerRentas()
        {
            try
            {
                List<Renta> rentas = await _context.Rentas.ToListAsync();
                return new Response<List<Renta>>(rentas);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener rentas: " + ex.Message);
            }
        }

        public async Task<Response<Renta>> ObtenerRentaPorId(int id)
        {
            try
            {
                Renta renta = await _context.Rentas.FindAsync(id);

                if (renta == null)
                {
                    return new Response<Renta>("No se encontró ninguna renta con el ID proporcionado.");
                }

                return new Response<Renta>(renta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la renta: " + ex.Message);
            }
        }

        public async Task<Response<Renta>> CrearRenta(RentaDTO rentaDTO)
        {
            try
            {
                Renta renta = new Renta
                {
                    ClienteFK = rentaDTO.ClienteFK,
                    CarritoFK = rentaDTO.CarritoFK,
                    VendedorFK = rentaDTO.VendedorFK,
                    HoraInicio = rentaDTO.HoraInicio,
                    HoraFinal = rentaDTO.HoraFinal,
                    Total = rentaDTO.Total
                };

                _context.Rentas.Add(renta);
                await _context.SaveChangesAsync();

                return new Response<Renta>(renta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la renta: " + ex.Message);
            }
        }

        public async Task<Response<Renta>> ActualizarRenta(int id, RentaDTO rentaDTO)
        {
            try
            {
                Renta renta = await _context.Rentas.FindAsync(id);

                if (renta == null)
                {
                    return new Response<Renta>("No se encontró ninguna renta con el ID proporcionado.");
                }

                renta.ClienteFK = rentaDTO.ClienteFK;
                renta.CarritoFK = rentaDTO.CarritoFK;
                renta.VendedorFK = rentaDTO.VendedorFK;
                renta.HoraInicio = rentaDTO.HoraInicio;
                renta.HoraFinal = rentaDTO.HoraFinal;
                renta.Total = rentaDTO.Total;

                _context.Entry(renta).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Response<Renta>(renta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la renta: " + ex.Message);
            }
        }

        public async Task<Response<Renta>> EliminarRenta(int id)
        {
            try
            {
                Renta renta = await _context.Rentas.FindAsync(id);

                if (renta == null)
                {
                    return new Response<Renta>("No se encontró ninguna renta con el ID proporcionado.");
                }

                _context.Rentas.Remove(renta);
                await _context.SaveChangesAsync();

                return new Response<Renta>(renta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la renta: " + ex.Message);
            }
        }
    }
}
