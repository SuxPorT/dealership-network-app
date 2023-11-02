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
    }
}
