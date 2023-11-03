using AutoMapper;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntityInputModel, TEntity> : IBaseRepository<TEntityInputModel, TEntity> 
        where TEntityInputModel : BaseInputModel
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<TEntity> GetAll()
            => _context.Set<TEntity>().ToList();

        public TEntity GetById(int id)
            => _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);

        public TEntity Add(TEntityInputModel inputModel)
        {
            var entity = _mapper.Map<TEntity>(inputModel);

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntityInputModel inputModel, int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(inputModel, entity);

            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Remove(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
