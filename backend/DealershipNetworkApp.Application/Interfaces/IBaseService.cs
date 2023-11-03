using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IBaseService<TEntityInputModel, TEntity> 
        where TEntityInputModel: BaseInputModel
        where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntityInputModel inputModel);
        TEntity Update(TEntityInputModel inputModel, int id);
        TEntity Remove(int id);
    }
}
