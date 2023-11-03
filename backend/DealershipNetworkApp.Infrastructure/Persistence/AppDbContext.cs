using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Infrastructure.Persistence.Configurations;
using DealershipNetworkApp.Infrastructure.Persistence.Utils;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => EntityConfiguration.ConfigureOnModelCreating(modelBuilder);

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        entry.Property("IsActive").CurrentValue = true;
                        break;
                    case EntityState.Modified:
                        entry.Property("ModifiedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Property("ModifiedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        entry.Property("IsActive").CurrentValue = false;
                        break;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        entry.Property("IsActive").CurrentValue = true;
                        break;
                    case EntityState.Modified:
                        entry.Property("ModifiedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Property("ModifiedAt").CurrentValue = ConvertTimeZone.HrBrasilia(DateTime.UtcNow);
                        entry.Property("IsActive").CurrentValue = false;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
