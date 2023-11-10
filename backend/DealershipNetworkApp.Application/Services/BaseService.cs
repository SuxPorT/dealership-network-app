using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Interfaces;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Application.Services
{
    public class BaseService<TEntityInputModel, TEntity, TEntityViewModel> 
        : IBaseRepository<TEntityInputModel, TEntity, TEntityViewModel> 
        where TEntityInputModel : BaseInputModel
        where TEntity : BaseEntity
        where TEntityViewModel: BaseViewModel
    {
        private readonly IBaseRepository<TEntityInputModel, TEntity, TEntityViewModel> _repository;

        public BaseService(IBaseRepository<TEntityInputModel, TEntity, TEntityViewModel> repository)
            => _repository = repository;

        public async Task<IList<TEntityViewModel>> GetAll()
            => await _repository.GetAll();

        public async Task<TEntityViewModel> GetById(int id)
            => await _repository.GetById(id);

        public async Task<TEntityViewModel> Add(TEntityInputModel inputModel)
            => await _repository.Add(inputModel);

        public async Task<TEntityViewModel> Update(TEntityInputModel inputModel, int id)
            => await _repository.Update(inputModel, id);

        public async Task<TEntityViewModel> Remove(int id)
            => await _repository.Remove(id);
    }
}
