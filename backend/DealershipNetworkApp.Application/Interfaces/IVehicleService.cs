using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IVehicleService : IBaseService<VehicleInputModel, Vehicle> { }
}
