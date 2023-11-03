using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class PhoneService : BaseService<PhoneInputModel, Phone>, IPhoneService
    {
        public PhoneService(IPhoneRepository repository) : base(repository) { }
    }
}
