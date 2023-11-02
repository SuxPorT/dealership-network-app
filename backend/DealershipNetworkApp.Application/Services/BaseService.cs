using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Repositories;

namespace DealershipNetworkApp.Application.Services
{
    public class BaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
            => _repository = repository;

        public IList<TEntity> GetAll()
            => _repository.GetAll();

        public TEntity GetById(int id)
            => _repository.GetById(id);
    }
}
