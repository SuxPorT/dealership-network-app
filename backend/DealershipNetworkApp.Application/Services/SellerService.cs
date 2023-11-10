using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class SellerService 
        : BaseService<SellerInputModel, Seller, SellerViewModel>, ISellerService
    {
        public SellerService(ISellerRepository repository) : base(repository) { }
    }
}
