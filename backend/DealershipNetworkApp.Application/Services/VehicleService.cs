using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
            => _repository = repository;

        public async Task<IList<Vehicle>> GetAll()
            => await _repository.GetAll();

        public async Task<Vehicle> GetByChassisNumber(string chassisNumber)
            => await _repository.GetByChassisNumber(chassisNumber);

        public async Task<Vehicle> Add(VehicleInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber)
            => await _repository.UpdateByChassisNumber(inputModel, chassisNumber);

        public async Task<Vehicle> RemoveByChassisNumber(Vehicle vehicle)
            => await _repository.RemoveByChassisNumber(vehicle);
    }
}
