using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IVehicleService : IBaseService<VehicleInputModel, Vehicle> 
    {
        Task<Vehicle> GetByChassisNumber(string chassisNumber);
        Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber);
    }
}
