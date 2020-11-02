using Microsoft.EntityFrameworkCore;
using OrdenesBlazorWasm.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesBlazorWasm.Server.DAL {
    public class Contexto : DbContext{

        public Contexto(DbContextOptions options):base(options) {}

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Suplidor> Suplidores { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Producto>().HasData(
                new Producto { ProductoId = 1 , Descripcion = "Cafe" , Existencia = 3 , Precio = 15 },
                new Producto { ProductoId = 2 , Descripcion = "Soda" , Existencia = 5 , Precio = 20 }
                );

            modelBuilder.Entity<Suplidor>().HasData(
                new Suplidor { SuplidorId = 1 , Nombre = "Surtidora perez"  } ,
                new Suplidor { SuplidorId = 2 , Nombre = "Surtidora mendez"}
                );

        }

    }
}
