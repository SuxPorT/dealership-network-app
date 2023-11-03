using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class VehicleService : BaseService<VehicleInputModel, Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository) : base(repository)
            => _repository = repository;

        public async Task<Vehicle> GetByChassisNumber(string chassisNumber)
            => await _repository.GetByChassisNumber(chassisNumber);

        public async Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber)
            => await _repository.UpdateByChassisNumber(inputModel, chassisNumber);
    }
}
