using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntityInputModel, TEntity, TEntityViewModel> 
        : IBaseRepository<TEntityInputModel, TEntity, TEntityViewModel> 
        where TEntityInputModel : BaseInputModel
        where TEntity: BaseEntity
        where TEntityViewModel : BaseViewModel
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<TEntityViewModel>> GetAll()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            var viewModels = entities.Select(_mapper.Map<TEntityViewModel>).ToList();

            return viewModels;
        }

        public async Task<TEntityViewModel> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<TEntityViewModel>(entity);
            return viewModel;
        }

        public async Task<TEntityViewModel> Add(TEntityInputModel inputModel)
        {
            var entity = _mapper.Map<TEntity>(inputModel);

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<TEntityViewModel>(entity);
            return viewModel;
        }

        public async Task<TEntityViewModel> Update(TEntityInputModel inputModel, int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);    

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<TEntityViewModel>(entity);
            return viewModel;
        }

        public async Task<TEntityViewModel> Remove(int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            var viewModel = _mapper.Map<TEntityViewModel>(entity);
            return viewModel;
        }
    }
}
