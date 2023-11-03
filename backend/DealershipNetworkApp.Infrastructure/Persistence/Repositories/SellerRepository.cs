using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SellerRepository : BaseRepository<SellerInputModel, Seller>, ISellerRepository
    {
        public SellerRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
