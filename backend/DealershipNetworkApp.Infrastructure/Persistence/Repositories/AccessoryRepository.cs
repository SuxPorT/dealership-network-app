using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class AccessoryRepository : BaseRepository<AccessoryInputModel, Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
