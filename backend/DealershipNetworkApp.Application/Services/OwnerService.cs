using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class OwnerService : BaseService<OwnerInputModel, Owner>, IOwnerService
    {
        private readonly IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository) : base(repository)
            => _repository = repository;

        public async Task<Owner> GetByCpfCnpj(string cpfCnpj)
                => await _repository.GetByCpfCnpj(cpfCnpj);

        public async Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj)
            => await _repository.UpdateByCpfCnpj(inputModel, cpfCnpj);
    }
}
