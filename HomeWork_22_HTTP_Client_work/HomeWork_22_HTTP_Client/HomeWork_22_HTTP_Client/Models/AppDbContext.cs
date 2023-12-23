using Microsoft.EntityFrameworkCore;


namespace HomeWork_22_HTTP_Client.Models
{
    internal class AppDbContext: DbContext
    {
        public DbSet <CurrencyAndTime> Currencys { get; set; }
    
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
