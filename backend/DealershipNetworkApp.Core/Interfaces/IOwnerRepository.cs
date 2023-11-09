using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IOwnerRepository
    {
        Task<IList<Owner>> GetAll();
        Task<Owner> GetByCpfCnpj(string cpfCnpj);
        Task<Owner> Add(OwnerInputModel inputModel);
        Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj);
        Task<Owner> RemoveByCpfCnpj(Owner owner);
    }
}
