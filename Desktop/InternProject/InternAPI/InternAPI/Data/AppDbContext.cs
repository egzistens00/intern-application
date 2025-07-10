using Microsoft.EntityFrameworkCore;
using InternAPI.Models;

namespace InternAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; } = null!;
    }
}
