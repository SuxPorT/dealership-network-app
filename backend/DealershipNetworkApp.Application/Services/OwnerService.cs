using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class OwnerService : BaseService<Owner>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository) : base(repository) { }
    }
}
