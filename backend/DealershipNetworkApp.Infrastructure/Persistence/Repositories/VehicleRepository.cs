using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;
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

        public async Task<IList<VehicleViewModel>> GetAll()
        {
            var entities = await _context.Vehicles.ToListAsync();
            var viewModels = entities.Select(_mapper.Map<VehicleViewModel>).ToList();

            return viewModels;
        }

        public async Task<VehicleViewModel> GetByChassisNumber(string chassisNumber)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.ChassisNumber == chassisNumber);
            if (entity == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<VehicleViewModel>(entity);
            return viewModel;
        }

        public async Task<VehicleViewModel> Add(VehicleInputModel inputModel)
        {
            var entity = _mapper.Map<Vehicle>(inputModel);

            _context.Vehicles.Add(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<VehicleViewModel>(entity);

            return viewModel;
        }

        public async Task<VehicleViewModel> UpdateByChassisNumber(VehicleInputModel inputModel, string chassisNumber)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.ChassisNumber == chassisNumber);
            if (entity == null)
            {
                return null;
            };

            _mapper.Map(inputModel, entity);

            _context.Vehicles.Update(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<VehicleViewModel>(entity);

            return viewModel;
        }

        public async Task<VehicleViewModel> RemoveByChassisNumber(string chassisNumber)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.ChassisNumber == chassisNumber);
            if (entity == null)
            {
                return null;
            }

            _context.Vehicles.Remove(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<VehicleViewModel>(entity);

            return viewModel;
        }
    }
}
