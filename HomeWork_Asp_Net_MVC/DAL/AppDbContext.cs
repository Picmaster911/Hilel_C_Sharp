using Microsoft.EntityFrameworkCore;
using NoteContracs;


namespace DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet <MyNote> MyNotes { get; set; }  
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
