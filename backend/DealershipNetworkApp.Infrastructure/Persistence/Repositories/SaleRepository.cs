using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SaleRepository 
        : BaseRepository<SaleInputModel, Sale, SaleViewModel>, ISaleRepository
    {
        public SaleRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
