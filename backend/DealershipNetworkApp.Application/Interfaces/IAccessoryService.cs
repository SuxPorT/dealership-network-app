using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IAccessoryService 
        : IBaseService<AccessoryInputModel, Accessory, AccessoryViewModel> { }
}
