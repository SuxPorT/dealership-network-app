using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<SaleInputModel, Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<Sale> GetById(int id)
            => await _context.Sales.FirstOrDefaultAsync(e => e.Id == id);
    }
}
