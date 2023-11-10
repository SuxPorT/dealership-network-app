using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class AccessoryRepository
        : BaseRepository<AccessoryInputModel, Accessory, AccessoryViewModel>, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
