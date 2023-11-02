using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity obj, int id);
        TEntity Remove(int id);
    }
}
