using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : BaseRepository<VehicleInputModel, Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
