using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<VehicleInputModel, Vehicle> 
    {
        Task<Vehicle> GetByChassisNumber(string chassisNumber);
        Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber);
    }
}
