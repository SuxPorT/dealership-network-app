using DealershipNetworkApp.Core.Entities;
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
        {
            modelBuilder.Entity<Owner>().HasKey(e => new { e.Id, e.CpfCnpj });
            modelBuilder.Entity<Vehicle>().HasKey(e => new { e.Id, e.ChassisNumber });

            modelBuilder.Entity<Accessory>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Owner>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Phone>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Sale>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Seller>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Vehicle>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
        }

        public override int SaveChanges()
        {
            foreach (
                var entry in ChangeTracker.Entries()
                                          .Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null)
            ) 
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
    }
}
