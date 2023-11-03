using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class PhoneRepository : BaseRepository<PhoneInputModel, Phone>, IPhoneRepository
    {
        public PhoneRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
