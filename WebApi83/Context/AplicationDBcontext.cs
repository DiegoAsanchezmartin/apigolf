using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace WebApi83.Context
{
    public class AplicationDBcontext : DbContext
    {
        public AplicationDBcontext(DbContextOptions options) : base(options) 
        { }

        //Modelos a Mapear
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Renta> Rentas { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Carritos> Carritos { get; set; }
        public DbSet<RentaActiva> RentaActiva { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    //insertar en tabla roles 
        //    modelBuilder.Entity<Usuario>().HasData(
        //        new Usuario 
        //        {
        //            PkUsuario = 1,
        //            Nombre = "Diego",
        //            User = "diego",
        //            Password = "12345",
        //            FkRol = 1
        //        }

        //        );

        //    //insertar en la trabla usuarios
        //    modelBuilder.Entity<Rol>().HasData(
        //        new Rol 
        //        {
        //            PkRol = 1,
        //            Nombre = "sa"
        //        }
        //        );
        
        //}
    }
}
