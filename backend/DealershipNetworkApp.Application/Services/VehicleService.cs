using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class VehicleService : BaseService<VehicleInputModel, Vehicle>, IVehicleService
    {
        public VehicleService(IVehicleRepository repository) : base(repository) { }
    }
}
