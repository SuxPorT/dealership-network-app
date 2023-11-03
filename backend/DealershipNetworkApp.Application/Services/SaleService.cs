using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class SaleService : BaseService<SaleInputModel, Sale>, ISaleService
    {
        public SaleService(ISaleRepository repository) : base(repository) { }
    }
}
