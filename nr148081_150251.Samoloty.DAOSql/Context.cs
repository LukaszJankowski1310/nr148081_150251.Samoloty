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
            optionsBuilder.UseSqlite("Data source=planes");
        }

        public DbSet<Plane> Planes { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}
