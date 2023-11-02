using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context) { }
    }
}
