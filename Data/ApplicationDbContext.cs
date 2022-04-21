using IGDB.Models;
using Microsoft.EntityFrameworkCore;

namespace IGDB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
