using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr148081_150251.Samoloty.DAOSql
{
    public class Context : DbContext
    {

        public Context() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlite(_configuration.GetConnectionString("sqlite"));
            optionsBuilder.UseSqlite("Data source=planess");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>()
                .HasKey(p => p.Id);


            modelBuilder.Entity<Plane>()
                .Property(p => p.CompanyId);

            modelBuilder.Entity<Plane>()
              .HasOne(p => (Company)p.Company) 
              .WithMany()
              .HasForeignKey(p => p.CompanyId);


            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);
        }


        public DbSet<Plane> Planes { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}
