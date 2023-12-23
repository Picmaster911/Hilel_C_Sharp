using HomeWork_22_HTTP_Client.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_22_HTTP_Client.DataProvider
{
    internal class AppDbContext: DbContext
    {
        public DbSet <Currency> Movies { get; set; }
    
        public AppDbContext ()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MyCurrency.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
