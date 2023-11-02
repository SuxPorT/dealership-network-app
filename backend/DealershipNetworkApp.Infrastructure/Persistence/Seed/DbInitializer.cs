using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Infrastructure.Persistence.Seed
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();

            SeedAccessories(context);
            SeedOwners(context);
            SeedPhones(context);
            SeedSales(context);
            SeedSellers(context);
            SeedVehicles(context);
        }

        private static void SeedAccessories(AppDbContext context)
        {
            if (context.Accessories.Any()) return;

            var accessories = new Accessory[]
            {
                new Accessory
                {
                    Description = "Headlight",
                    VehicleChassisNumber = "abc"
                },
                new Accessory
                {
                    Description = "Radio",
                    VehicleChassisNumber = "abc"
                },
                new Accessory
                {
                    Description = "Seat cover",
                    VehicleChassisNumber = "wxyz"
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
                    CpfCnpj = "11122233344",
                    HiringType = "F",
                    Name = "João das Couves",
                    Email = "joao@email.com",
                    BirthDate = new DateTime(2000, 1, 1),
                    City = "Curitiba",
                    UF = "PR",
                    CEP = "123"
                },
                new Owner
                {
                    CpfCnpj = "99922233344",
                    HiringType = "F",
                    Name = "José Silva",
                    Email = "jose@email.com",
                    BirthDate = new DateTime(1999, 1, 25),
                    City = "São Paulo",
                    UF = "SP",
                    CEP = "321"
                },
                new Owner
                {
                    CpfCnpj = "99988844455",
                    HiringType = "J",
                    Name = "Maria das Graças",
                    Email = "maria@email.com",
                    BirthDate = new DateTime(1985, 1, 1),
                    City = "Cascavél",
                    UF = "PR",
                    CEP = "111"
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
                    OwnerCpfCnpj = "11122233344"
                },
                new Phone
                {
                    Number = "42 4212-3221",
                    OwnerCpfCnpj = "11122233344"
                },
                new Phone
                {
                    Number = "5541933334444",
                    OwnerCpfCnpj = "99922233344"
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
                    CreatedAt = DateTime.Now.AddDays(-2).AddHours(12),
                    Price = 12000,
                    VehicleChassisNumber = "abc",
                    OwnerCpfCnpj = "11122233344"
                },
                new Sale
                {
                    CreatedAt = DateTime.Now.AddDays(-12).AddHours(53).AddMinutes(22),
                    Price = 13000,
                    VehicleChassisNumber = "abcde",
                    OwnerCpfCnpj = "99922233344"
                },
                new Sale
                {
                    CreatedAt = DateTime.Now.AddHours(8).AddMinutes(23),
                    Price = 10500,
                    VehicleChassisNumber = "wxyz",
                    OwnerCpfCnpj = "99988844455"
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
                    BaseSalary = 1200.00m
                },
                new Seller
                {
                    Name = "Maria",
                    BaseSalary = 1333.99m
                },
                new Seller
                {
                    Name = "Bernardo",
                    BaseSalary = 999.99m
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
                    ChassisNumber = "abc",
                    Model = "Logan",
                    Year = 2008,
                    Color = "Red",
                    Price = 34000,
                    Mileage = 12000,
                    SystemVersion = "1.0",
                    OwnerCpfCnpj = "11122233344"
                },
                new Vehicle
                {
                    ChassisNumber = "abcde",
                    Model = "Palio",
                    Year = 2012,
                    Color = "Grey",
                    Price = 24700,
                    Mileage = 10100,
                    SystemVersion = "1.0",
                    OwnerCpfCnpj = "99922233344"
                },
                new Vehicle
                {
                    ChassisNumber = "wxyz",
                    Model = "Kombi",
                    Year = 2000,
                    Color = "White",
                    Price = 29750,
                    Mileage = 12000,
                    SystemVersion = "1.5",
                    OwnerCpfCnpj = "99988844455"
                }
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
