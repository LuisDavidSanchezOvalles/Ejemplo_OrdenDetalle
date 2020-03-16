using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PruebaOrden1.Entidades;

namespace PruebaOrden1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Orden> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = OrdenDB.db");
        }
    }
}
