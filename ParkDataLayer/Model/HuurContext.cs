using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurContext : DbContext
    {
        
        public DbSet<EF_Huis> Huis { get; set; }
        public DbSet<EF_Huurcontract> Huurcontract { get; set; }
        public DbSet<EF_Huurder> Huurder { get; set; }
        public DbSet<EF_Park> Park { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=FRENK\SQLEXPRESS;Initial Catalog=eindopdracht_EF;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
