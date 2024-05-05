using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesData
{
    public class HotelContext : DbContext
    {
        public DbSet<Cabania> Cabañas { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=ObligatorioProgramacion;Integrated Security=true;");
        }
    }
}
