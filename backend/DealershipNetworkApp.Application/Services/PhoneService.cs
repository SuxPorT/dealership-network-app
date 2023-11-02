using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        public PhoneService(IPhoneRepository repository) : base(repository) { }
    }
}
