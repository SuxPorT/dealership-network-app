using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IBaseRepository<TEntityInputModel, TEntity>
        where TEntityInputModel : BaseInputModel
        where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntityInputModel inputModel);
        TEntity Update(TEntityInputModel inputModel, int id);
        TEntity Remove(int id);
    }
}
