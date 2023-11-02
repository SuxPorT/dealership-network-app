using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;

namespace DealershipNetworkApp.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
            => _context = context;

        public IList<TEntity> GetAll()
            => _context.Set<TEntity>().ToList();

        public TEntity GetById(int id)
            => _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity obj, int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return null;
            }

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
