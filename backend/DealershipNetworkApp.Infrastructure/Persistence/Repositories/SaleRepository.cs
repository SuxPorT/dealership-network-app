using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<SaleInputModel, Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
