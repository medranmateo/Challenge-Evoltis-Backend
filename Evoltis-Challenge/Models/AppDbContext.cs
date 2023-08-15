using Microsoft.EntityFrameworkCore;


namespace Evoltis_Challenge.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Producto> Producto { get; set; }

    }
}
