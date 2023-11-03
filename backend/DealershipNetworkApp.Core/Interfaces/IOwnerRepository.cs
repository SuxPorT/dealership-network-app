using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IOwnerRepository : IBaseRepository<OwnerInputModel, Owner> 
    {
        Task<Owner> GetByCpfCnpj(string cpfCnpj);
        Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj);
    }
}
