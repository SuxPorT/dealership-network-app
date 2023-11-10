using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<IList<VehicleViewModel>> GetAll();
        Task<VehicleViewModel> Add(VehicleInputModel inputModel);
        Task<VehicleViewModel> GetByChassisNumber(string chassisNumber);
        Task<VehicleViewModel> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber);
        Task<VehicleViewModel> RemoveByChassisNumber(string chassisNumber);
    }
}
