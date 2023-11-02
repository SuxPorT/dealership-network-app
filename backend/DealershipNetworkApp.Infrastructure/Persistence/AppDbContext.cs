using DealershipNetworkApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
