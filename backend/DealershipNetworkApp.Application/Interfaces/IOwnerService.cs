using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IOwnerService : IBaseService<OwnerInputModel, Owner> 
    {
        Task<Owner> GetByCpfCnpj(string cpfCnpj);
        Task<Owner> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj);
    }
}
