using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
            => _repository = repository;

        public async Task<IList<OwnerViewlModel>> GetAll()
            => await _repository.GetAll();

        public async Task<OwnerViewlModel> GetByCpfCnpj(string cpfCnpj)
                => await _repository.GetByCpfCnpj(cpfCnpj);

        public async Task<OwnerViewlModel> Add(OwnerInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<OwnerViewlModel> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj)
            => await _repository.UpdateByCpfCnpj(inputModel, cpfCnpj);

        public async Task<OwnerViewlModel> RemoveByCpfCnpj(string cpfCnpj)
            => await _repository.RemoveByCpfCnpj(cpfCnpj);
    }
}
