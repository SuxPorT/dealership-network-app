using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;
using DealershipNetworkApp.Core.Interfaces.Services;

namespace DealershipNetworkApp.Application.Services
{
    public class SaleService : BaseService<Sale>, ISaleService
    {
        public SaleService(ISaleRepository repository) : base(repository) { }
    }
}
