using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;

namespace DealershipNetworkApp.Application.Services
{
    public class BaseService<TEntityInputModel, TEntity> : IBaseRepository<TEntityInputModel, TEntity> 
        where TEntityInputModel : BaseInputModel
        where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntityInputModel, TEntity> _repository;

        public BaseService(IBaseRepository<TEntityInputModel, TEntity> repository)
            => _repository = repository;

        public async Task<IList<TEntity>> GetAll()
            => await _repository.GetAll();

        public async Task<TEntity> GetById(int id)
            => await _repository.GetById(id);

        public async Task<TEntity> Add(TEntityInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<TEntity> Update(TEntityInputModel inputModel, int id)
            => await _repository.Update(inputModel, id);

        public async Task<TEntity> Remove(TEntity entity)
            => await _repository.Remove(entity);
    }
}
