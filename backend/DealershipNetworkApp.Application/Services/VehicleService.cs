using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
            => _repository = repository;

        public async Task<IList<VehicleViewModel>> GetAll()
            => await _repository.GetAll();

        public async Task<VehicleViewModel> GetByChassisNumber(string chassisNumber)
            => await _repository.GetByChassisNumber(chassisNumber);

        public async Task<VehicleViewModel> Add(VehicleInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<VehicleViewModel> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber)
            => await _repository.UpdateByChassisNumber(inputModel, chassisNumber);

        public async Task<VehicleViewModel> RemoveByChassisNumber(string chassisNumber)
            => await _repository.RemoveByChassisNumber(chassisNumber);
    }
}
