using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    internal class AppDbContext: DbContext
    {
        public DbSet <Movie> Movies { get; set; }
    
        public AppDbContext ()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = movies.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
