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
            SeedAccessoriesVehicles(context);
            SeedPhones(context);
            SeedSellers(context);
            SeedSales(context);
        }

        private static async void SeedAccessories(AppDbContext context)
        {
            if (context.Accessories.Any()) return;

            var accessories = new Accessory[]
            {
                new Accessory
                {
                    Description = "Headlight"
                },
                new Accessory
                {
                    Description = "Radio"
                },
                new Accessory
                {
                    Description = "Seat cover"
                }
            };

            context.Accessories.AddRange(accessories);
            await context.SaveChangesAsync();
        }

        private static async void SeedAccessoriesVehicles(AppDbContext context)
        {
            if (context.AccessoriesVehicles.Any()) return;

            var accessoriesVehicles = new AccessoryVehicle[]
            {
                new AccessoryVehicle
                {
                    Id = 1,
                    AccessoryId = 1,
                    VehicleChassisNumber = "abc"
                },
                new AccessoryVehicle
                {
                    Id = 2,
                    AccessoryId = 2,
                    VehicleChassisNumber = "abc"
                },
                new AccessoryVehicle
                {
                    Id = 3,
                    AccessoryId = 3,
                    VehicleChassisNumber = "wxyz"
                }
            };

            context.AccessoriesVehicles.AddRange(accessoriesVehicles);
            await context.SaveChangesAsync();
        }

        private static async void SeedOwners(AppDbContext context)
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
            await context.SaveChangesAsync();
        }

        private static async void SeedPhones(AppDbContext context)
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
            await context.SaveChangesAsync();
        }

        private static async void SeedSales(AppDbContext context)
        {
            if (context.Sales.Any()) return;

            var sales = new Sale[]
            {
                new Sale
                {
                    Price = 12000,
                    VehicleChassisNumber = "abc",
                    SellerId = 1,
                    CreatedAt = DateTime.Now.AddDays(-2).AddHours(12)
                },
                new Sale
                {
                    Price = 13000,
                    VehicleChassisNumber = "abcde",
                    SellerId = 2,
                    CreatedAt = DateTime.Now.AddDays(-12).AddHours(53).AddMinutes(22)
                },
                new Sale
                {
                    Price = 10500,
                    VehicleChassisNumber = "wxyz",
                    SellerId = 3,
                    CreatedAt = DateTime.Now.AddHours(8).AddMinutes(23)
                }
            };

            context.Sales.AddRange(sales);
            await context.SaveChangesAsync();
        }

        private static async void SeedSellers(AppDbContext context)
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
            await context.SaveChangesAsync();
        }

        private static async void SeedVehicles(AppDbContext context)
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
            await context.SaveChangesAsync();
        }
    }
}
