using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public VehicleRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<Vehicle>> GetAll()
            => await _context.Vehicles.ToListAsync();

        public async Task<Vehicle> GetByChassisNumber(string chassisNumber)
            => await _context.Vehicles.FindAsync(chassisNumber);

        public async Task<Vehicle> Add(VehicleInputModel inputModel)
        {
            var entity = _mapper.Map<Vehicle>(inputModel);

            _context.Vehicles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

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

        public async Task<Vehicle> RemoveByChassisNumber(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
