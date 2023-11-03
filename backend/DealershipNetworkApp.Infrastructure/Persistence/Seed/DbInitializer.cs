using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Infrastructure.Persistence.Seed
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();

            SeedOwners(context);
            SeedVehicles(context);
            SeedAccessories(context);
            SeedPhones(context);
            SeedSellers(context);
            SeedSales(context);
        }

        private static void SeedAccessories(AppDbContext context)
        {
            if (context.Accessories.Any()) return;

            var accessories = new Accessory[]
            {
                new Accessory
                {
                    Description = "Headlight",
                    VehicleChassisNumber = "abc",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Accessory
                {
                    Description = "Radio",
                    VehicleChassisNumber = "abc",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Accessory
                {
                    Description = "Seat cover",
                    VehicleChassisNumber = "wxyz",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            context.Accessories.AddRange(accessories);
            context.SaveChanges();
        }

        private static void SeedOwners(AppDbContext context)
        {
            if (context.Owners.Any()) return;

            var owners = new Owner[]
            {
                new Owner
                {
                    Id = 1,
                    CpfCnpj = "11122233344",
                    HiringType = "F",
                    Name = "João das Couves",
                    Email = "joao@email.com",
                    BirthDate = new DateTime(2000, 1, 1),
                    City = "Curitiba",
                    UF = "PR",
                    CEP = "123",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Owner
                {
                    Id = 2,
                    CpfCnpj = "99922233344",
                    HiringType = "F",
                    Name = "José Silva",
                    Email = "jose@email.com",
                    BirthDate = new DateTime(1999, 1, 25),
                    City = "São Paulo",
                    UF = "SP",
                    CEP = "321",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Owner
                {
                    Id = 3,
                    CpfCnpj = "99988844455",
                    HiringType = "J",
                    Name = "Maria das Graças",
                    Email = "maria@email.com",
                    BirthDate = new DateTime(1985, 1, 1),
                    City = "Cascavél",
                    UF = "PR",
                    CEP = "111",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            context.Owners.AddRange(owners);
            context.SaveChanges();
        }

        private static void SeedPhones(AppDbContext context)
        {
            if (context.Phones.Any()) return;

            var phones = new Phone[]
            {
                new Phone
                {
                    Number = "41 91111-2222",
                    OwnerCpfCnpj = "11122233344",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Phone
                {
                    Number = "42 4212-3221",
                    OwnerCpfCnpj = "11122233344",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Phone
                {
                    Number = "5541933334444",
                    OwnerCpfCnpj = "99922233344",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            context.Phones.AddRange(phones);
            context.SaveChanges();
        }

        private static void SeedSales(AppDbContext context)
        {
            if (context.Sales.Any()) return;

            var sales = new Sale[]
            {
                new Sale
                {
                    Price = 12000,
                    VehicleChassisNumber = "abc",
                    SellerId = 1,
                    CreatedAt = DateTime.Now.AddDays(-2).AddHours(12),
                    IsActive = true
                },
                new Sale
                {
                    Price = 13000,
                    VehicleChassisNumber = "abcde",
                    SellerId = 2,
                    CreatedAt = DateTime.Now.AddDays(-12).AddHours(53).AddMinutes(22),
                    IsActive = true
                },
                new Sale
                {
                    Price = 10500,
                    VehicleChassisNumber = "wxyz",
                    SellerId = 3,
                    CreatedAt = DateTime.Now.AddHours(8).AddMinutes(23),
                    IsActive = true
                }
            };

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void SeedSellers(AppDbContext context)
        {
            if (context.Sellers.Any()) return;

            var sellers = new Seller[]
            {
                new Seller
                {
                    Name = "João",
                    BaseSalary = 1200.00m,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Seller
                {
                    Name = "Maria",
                    BaseSalary = 1333.99m,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Seller
                {
                    Name = "Bernardo",
                    BaseSalary = 999.99m,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            context.Sellers.AddRange(sellers);
            context.SaveChanges();
        }

        private static void SeedVehicles(AppDbContext context)
        {
            if (context.Vehicles.Any()) return;

            var vehicles = new Vehicle[]
            {
                new Vehicle
                {
                    Id = 1,
                    ChassisNumber = "abc",
                    Model = "Logan",
                    Year = 2008,
                    Color = "Red",
                    Price = 34000,
                    Mileage = 12000,
                    SystemVersion = "1.0",
                    OwnerCpfCnpj = "11122233344",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Vehicle
                {
                    Id = 2,
                    ChassisNumber = "abcde",
                    Model = "Palio",
                    Year = 2012,
                    Color = "Grey",
                    Price = 24700,
                    Mileage = 10100,
                    SystemVersion = "1.0",
                    OwnerCpfCnpj = "99922233344",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Vehicle
                {
                    Id = 3,
                    ChassisNumber = "wxyz",
                    Model = "Kombi",
                    Year = 2000,
                    Color = "White",
                    Price = 29750,
                    Mileage = 12000,
                    SystemVersion = "1.5",
                    OwnerCpfCnpj = "99988844455",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
