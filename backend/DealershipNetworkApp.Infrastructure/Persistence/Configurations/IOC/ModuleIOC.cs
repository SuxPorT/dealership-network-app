using Autofac;

namespace DealershipNetworkApp.Infrastructure.Persistence.Configurations.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }
    }
}
