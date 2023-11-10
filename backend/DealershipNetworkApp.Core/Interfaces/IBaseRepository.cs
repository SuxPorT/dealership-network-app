using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;

namespace DealershipNetworkApp.Core.Interfaces
{
    public interface IBaseRepository<TEntityInputModel, TEntity, TEntityViewModel>
        where TEntityInputModel : BaseInputModel
        where TEntity: BaseEntity
        where TEntityViewModel : BaseViewModel
    {
        Task<IList<TEntityViewModel>> GetAll();
        Task<TEntityViewModel> GetById(int id);
        Task<TEntityViewModel> Add(TEntityInputModel inputModel);
        Task<TEntityViewModel> Update(TEntityInputModel inputModel, int id);
        Task<TEntityViewModel> Remove(int id);
    }
}
