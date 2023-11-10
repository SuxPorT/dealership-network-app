using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class SellerRepository 
        : BaseRepository<SellerInputModel, Seller, SellerViewModel>, ISellerRepository
    {
        public SellerRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
