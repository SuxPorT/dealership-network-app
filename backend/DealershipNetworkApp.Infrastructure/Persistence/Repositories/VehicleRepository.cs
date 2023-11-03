using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : BaseRepository<VehicleInputModel, Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Vehicle> GetByChassisNumber(string chassisNumber)
            => await _context.Vehicles.FindAsync(chassisNumber);

        public async Task<Vehicle> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber)
        {
            var entity = await GetByChassisNumber(chassisNumber);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);

            _context.Vehicles.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
