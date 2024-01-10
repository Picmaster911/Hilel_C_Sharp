using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace plc_wpf.Model
{
    internal class AppDbContext:DbContext
    {
        public DbSet<PLC_Conection> Plc_Conections { get; set; }

        public AppDbContext()
        {
          //  Database.EnsureDeleted();   // удаляем бд со старой схемой
          //  Database.EnsureCreated();   // создаем бд с новой схемой
                                        //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=plc_wpf;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
