using Microsoft.EntityFrameworkCore;

namespace HotelaATR4.Admin.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamLinks> TeamLinks { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
    }
}