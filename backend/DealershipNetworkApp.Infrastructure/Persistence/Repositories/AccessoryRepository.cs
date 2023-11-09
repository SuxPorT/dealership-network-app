using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class AccessoryRepository : BaseRepository<AccessoryInputModel, Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper)  { }

        public override async Task<Accessory> GetById(int id)
            => await _context.Accessories.FirstOrDefaultAsync(e => e.Id == id);
    }
}
