using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Core.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
