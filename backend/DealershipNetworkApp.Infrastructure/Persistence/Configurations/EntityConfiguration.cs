using DealershipNetworkApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Configurations
{
    public static class EntityConfiguration
    {
        public static void ConfigureOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(e =>
            {
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<AccessoryVehicle>(e =>
            {
                e.HasKey(e => new { e.AccessoryId, e.VehicleChassisNumber });
                e.HasIndex(e => e.Id).IsUnique();
                e.Property(e => e.Id).ValueGeneratedOnAdd();

                e.HasOne(e => e.Accessory)
                 .WithMany(e => e.AccessoriesVehicles)
                 .HasForeignKey(e => e.AccessoryId);

                e.HasOne(e => e.Vehicle)
                 .WithMany(e => e.AccessoriesVehicles)
                 .HasForeignKey(e => e.VehicleChassisNumber);
            });

            modelBuilder.Entity<Owner>(e =>
            {
                e.HasKey(e => e.CpfCnpj);
            });

            modelBuilder.Entity<Phone>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(e => e.Owner)
                 .WithMany(e => e.Phones)
                 .HasForeignKey(e => e.OwnerCpfCnpj);
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(e => e.Vehicle)
                 .WithOne(e => e.Sale)
                 .HasForeignKey<Sale>(e => e.VehicleChassisNumber);

                e.HasOne(e => e.Seller)
                 .WithMany(e => e.Sales)
                 .HasForeignKey(e => e.SellerId);
            });

            modelBuilder.Entity<Seller>(e =>
            {
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Vehicle>(e =>
            {
                e.HasKey(e => e.ChassisNumber);

                e.HasOne(e => e.Owner)
                 .WithMany(e => e.Vehicles)
                 .HasForeignKey(e => e.OwnerCpfCnpj);
            });

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
