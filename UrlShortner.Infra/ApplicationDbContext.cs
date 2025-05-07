using Microsoft.EntityFrameworkCore;
using UrlShortner.Entities;

namespace UrlShortner.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UrlEntity> Urls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
