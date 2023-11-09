using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SellerRepository : BaseRepository<SellerInputModel, Seller>, ISellerRepository
    {
        public SellerRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<Seller> GetById(int id)
            => await _context.Sellers.FirstOrDefaultAsync(e => e.Id == id);
    }
}
