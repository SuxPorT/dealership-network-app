using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<VehicleInputModel, Vehicle> { }
}
