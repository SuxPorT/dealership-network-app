using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
