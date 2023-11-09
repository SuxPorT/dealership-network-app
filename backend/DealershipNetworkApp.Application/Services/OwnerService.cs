using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
            => _repository = repository;

        public async Task<IList<Owner>> GetAll()
            => await _repository.GetAll();

        public async Task<Owner> GetByCpfCnpj(string cpfCnpj)
                => await _repository.GetByCpfCnpj(cpfCnpj);

        public async Task<Owner> Add(OwnerInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj)
            => await _repository.UpdateByCpfCnpj(inputModel, cpfCnpj);

        public async Task<Owner> RemoveByCpfCnpj(Owner owner)
            => await _repository.RemoveByCpfCnpj(owner);
    }
}
