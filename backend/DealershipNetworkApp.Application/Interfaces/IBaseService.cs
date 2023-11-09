using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;

namespace DealershipNetworkApp.Application.Interfaces.Services
{
    public interface IBaseService<TEntityInputModel, TEntity> 
        where TEntityInputModel: BaseInputModel
        where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntityInputModel inputModel);
        Task<TEntity> Update(TEntityInputModel inputModel, int id);
        Task<TEntity> Remove(TEntity entity);
    }
}
