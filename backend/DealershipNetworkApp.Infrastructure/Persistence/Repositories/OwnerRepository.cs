using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public OwnerRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<OwnerViewlModel>> GetAll()
        {
            var entities = await _context.Owners.ToListAsync();
            var viewModels = entities.Select(_mapper.Map<OwnerViewlModel>).ToList();

            return viewModels;
        }
            
        public async Task<OwnerViewlModel> GetByCpfCnpj(string cpfCnpj)
        {
            var entity = await _context.Owners.FirstOrDefaultAsync(e => e.CpfCnpj == cpfCnpj);
            if(entity == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<OwnerViewlModel>(entity);
            return viewModel;
        }

        public async Task<OwnerViewlModel> Add(OwnerInputModel inputModel)
        {
            var entity = _mapper.Map<Owner>(inputModel);

            _context.Owners.Add(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<OwnerViewlModel>(entity);
            return viewModel;
        }

        public async Task<OwnerViewlModel> UpdateByCpfCnpj(OwnerInputModel inputModel, string cpfCnpj)
        {
            var entity = await _context.Owners.FirstOrDefaultAsync(e => e.CpfCnpj == cpfCnpj);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);

            _context.Owners.Update(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<OwnerViewlModel>(entity);
            return viewModel;
        }

        public async Task<OwnerViewlModel> RemoveByCpfCnpj(string cpfCnpj)
        {
            var entity = await _context.Owners.FirstOrDefaultAsync(e => e.CpfCnpj == cpfCnpj);
            if (entity == null)
            {
                return null;
            }

            _context.Owners.Remove(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<OwnerViewlModel>(entity);
            return viewModel;
        }
    }
}
