using AppGMAO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGMAO.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-8HPEOE9\\SQLEXPRESS;Database=Clientes;User Id=sa;Password=Nicolas27112016?;TrustServerCertificate=True;");
        }
    }
}
