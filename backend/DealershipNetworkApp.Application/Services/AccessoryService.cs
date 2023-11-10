using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class AccessoryService 
        : BaseService<AccessoryInputModel, Accessory, AccessoryViewModel>, IAccessoryService
    {
        public AccessoryService(IAccessoryRepository repository) : base(repository) { }
    }
}
