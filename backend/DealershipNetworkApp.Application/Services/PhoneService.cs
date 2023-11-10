using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class PhoneService 
        : BaseService<PhoneInputModel, Phone, PhoneViewModel>, IPhoneService
    {
        public PhoneService(IPhoneRepository repository) : base(repository) { }
    }
}
