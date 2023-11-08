using DealershipNetworkApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Configurations
{
    public static class EntityConfiguration
    {
        public static void ConfigureOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<AccessoryVehicle>()
                .HasKey(e => new { e.AccessoryId, e.VehicleChassisNumber });
            modelBuilder.Entity<AccessoryVehicle>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<AccessoryVehicle>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AccessoryVehicle>()
                .HasOne(e => e.Accessory)
                .WithMany(e => e.AccessoriesVehicles)
                .HasForeignKey(e => e.AccessoryId);

            modelBuilder.Entity<AccessoryVehicle>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.AccessoriesVehicles)
                .HasForeignKey(e => e.VehicleChassisNumber);

            modelBuilder.Entity<Owner>()
                .HasKey(e => e.CpfCnpj);
            modelBuilder.Entity<Owner>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<Owner>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Phone>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Phone>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<Phone>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Phone>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Phones)
                .HasForeignKey(e => e.OwnerCpfCnpj);

            modelBuilder.Entity<Sale>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Vehicle)
                .WithOne(e => e.Sale)
                .HasForeignKey<Sale>(e => e.VehicleChassisNumber);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.SellerId);

            modelBuilder.Entity<Seller>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Vehicle>()
                .HasKey(e => e.ChassisNumber);
            modelBuilder.Entity<Vehicle>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.OwnerCpfCnpj);

            //modelBuilder.Entity<Accessory>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<AccessoryVehicle>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<Owner>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<Phone>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<Sale>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<Seller>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
            //modelBuilder.Entity<Vehicle>().HasQueryFilter(e => EF.Property<bool>(e, "IsActive"));
        }
    }
}
