using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IOwnerService
    {
        Task<IList<Owner>> GetAll();
        Task<Owner> GetByCpfCnpj(string cpfCnpj);
        Task<Owner> Add(OwnerInputModel inputModel);
        Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj);
        Task<Owner> RemoveByCpfCnpj(Owner owner);
    }
}
