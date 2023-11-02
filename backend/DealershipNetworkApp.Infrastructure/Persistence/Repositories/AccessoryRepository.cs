using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class AccessoryRepository : BaseRepository<Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context) : base(context) { }
    }
}
