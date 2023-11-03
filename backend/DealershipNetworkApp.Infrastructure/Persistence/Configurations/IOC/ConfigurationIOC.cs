using Autofac;
using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Application.Services;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Infrastructure.Persistence.Repositories;

namespace DealershipNetworkApp.Infrastructure.Persistence.Configurations.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            RegisterServicers(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterServicers(ContainerBuilder builder)
        {
            builder.RegisterType<AccessoryService>().As<IAccessoryService>();
            builder.RegisterType<OwnerService>().As<IOwnerService>();
            builder.RegisterType<PhoneService>().As<IPhoneService>();
            builder.RegisterType<SaleService>().As<ISaleService>();
            builder.RegisterType<SellerService>().As<ISellerService>();
            builder.RegisterType<VehicleService>().As<IVehicleService>();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<AccessoryRepository>().As<IAccessoryRepository>();
            builder.RegisterType<OwnerRepository>().As<IOwnerRepository>();
            builder.RegisterType<PhoneRepository>().As<IPhoneRepository>();
            builder.RegisterType<SaleRepository>().As<ISaleRepository>();
            builder.RegisterType<SellerRepository>().As<ISellerRepository>();
            builder.RegisterType<VehicleRepository>().As<IVehicleRepository>();
        }
    }
}
