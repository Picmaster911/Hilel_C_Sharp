using Microsoft.EntityFrameworkCore;
using NotesProcessor;


namespace DAL
{
    internal class AppDbContext: DbContext
    {
        public DbSet <MyNote> MyNotes { get; set; }
    
        public AppDbContext ()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MyNoteDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
