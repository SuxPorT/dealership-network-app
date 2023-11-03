using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class OwnerService : BaseService<OwnerInputModel, Owner>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository) : base(repository) { }
    }
}
