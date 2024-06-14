using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace Investing.Infrastructure.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AssetClass> AssetClass { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<SectorConfiguration> SectorConfiguration { get; set; }
        public DbSet<Asset> Asset { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
