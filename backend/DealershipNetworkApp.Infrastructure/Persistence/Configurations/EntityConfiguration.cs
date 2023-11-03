using DealershipNetworkApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Configurations
{
    public static class EntityConfiguration
    {
        public static void ConfigureOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Accessories)
                .HasForeignKey(e => e.VehicleChassisNumber);

            modelBuilder.Entity<Owner>()
                .HasKey(e => e.CpfCnpj);
            modelBuilder.Entity<Owner>()
                .HasIndex(e => new { e.Id, e.CpfCnpj })
                .IsUnique();
            modelBuilder.Entity<Owner>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Phone>()
                .HasIndex(e => new { e.Id, e.Number })
                .IsUnique();
            modelBuilder.Entity<Phone>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Phone>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Phones)
                .HasForeignKey(e => e.OwnerCpfCnpj);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Vehicle)
                .WithOne(e => e.Sale)
                .HasForeignKey<Sale>(e => e.VehicleChassisNumber);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.SellerId);

            modelBuilder.Entity<Vehicle>()
                .HasKey(e => e.ChassisNumber);
            modelBuilder.Entity<Vehicle>()
                .HasIndex(e => new { e.Id, e.ChassisNumber })
                .IsUnique();
            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.OwnerCpfCnpj);

            modelBuilder.Entity<Accessory>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Owner>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Phone>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Sale>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Seller>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            modelBuilder.Entity<Vehicle>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
        }
    }
}
