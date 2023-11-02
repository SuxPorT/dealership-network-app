using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class VehicleService : BaseService<Vehicle>, IVehicleService
    {
        public VehicleService(IVehicleRepository repository) : base(repository) { }
    }
}
