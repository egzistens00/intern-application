using Microsoft.EntityFrameworkCore;
using InternAPI.Models;
using InternAPI.Services;

namespace InternAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly VaultService _vaultService;

        public AppDbContext(DbContextOptions<AppDbContext> options, VaultService vaultService)
            : base(options)
        {
            _vaultService = vaultService;
        }

        public DbSet<Intern> Interns => Set<Intern>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var creds = _vaultService.GetDbCredentialsAsync().Result;
                var connectionString = $"Server=alif-intern-sqlserver.database.windows.net;Database=InternDB;User Id={creds.Username};Password={creds.Password};";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
