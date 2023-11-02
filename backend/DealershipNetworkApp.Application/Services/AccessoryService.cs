using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class AccessoryService : BaseService<Accessory>, IAccessoryService
    {
        public AccessoryService(IAccessoryRepository repository) : base(repository) { }
    }
}
