using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface ISaleService : IBaseService<SaleInputModel, Sale> { }
}
