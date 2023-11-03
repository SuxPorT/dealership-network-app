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

        public IList<TEntity> GetAll()
            => _repository.GetAll();

        public TEntity GetById(int id)
            => _repository.GetById(id);

        public TEntity Add(TEntityInputModel inputModel)
            => _repository.Add(inputModel);

        public TEntity Update(TEntityInputModel inputModel, int id)
            => _repository.Update(inputModel, id);

        public TEntity Remove(int id)
            => _repository.Remove(id);
    }
}
