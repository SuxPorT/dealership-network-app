using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IAccessoryRepository 
        : IBaseRepository<AccessoryInputModel, Accessory, AccessoryViewModel> { }
}
