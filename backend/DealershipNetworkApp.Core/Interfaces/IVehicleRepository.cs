using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IList<Vehicle>> GetAll();
        Task<Vehicle> Add(VehicleInputModel inputModel);
        Task<Vehicle> GetByChassisNumber(string chassisNumber);
        Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber);
        Task<Vehicle> RemoveByChassisNumber(Vehicle vehicle);
    }
}
