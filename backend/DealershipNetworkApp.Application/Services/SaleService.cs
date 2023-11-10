using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class SaleService 
        : BaseService<SaleInputModel, Sale, SaleViewModel>, ISaleService
    {
        public SaleService(ISaleRepository repository) : base(repository) { }
    }
}
