using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<IList<Vehicle>> GetAll();
        Task<Vehicle> Add(VehicleInputModel inputModel);
        Task<Vehicle> GetByChassisNumber(string chassisNumber);
        Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber);
        Task<Vehicle> RemoveByChassisNumber(Vehicle vehicle);
    }
}
