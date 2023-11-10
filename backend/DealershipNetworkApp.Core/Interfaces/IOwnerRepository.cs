using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IOwnerRepository
    {
        Task<IList<OwnerViewlModel>> GetAll();
        Task<OwnerViewlModel> GetByCpfCnpj(string cpfCnpj);
        Task<OwnerViewlModel> Add(OwnerInputModel inputModel);
        Task<OwnerViewlModel> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj);
        Task<OwnerViewlModel> RemoveByCpfCnpj(string cpfCnpj);
    }
}
