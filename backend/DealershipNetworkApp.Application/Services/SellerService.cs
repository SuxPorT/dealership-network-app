using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class SellerService : BaseService<Seller>, ISellerService
    {
        public SellerService(ISellerRepository repository) : base(repository) { }
    }
}
