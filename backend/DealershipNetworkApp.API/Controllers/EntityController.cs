using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.API.Controllers
{
    public abstract class EntityController<TEntityInpuitModel, TEntity, TEntityViewModel> : ControllerBase
        where TEntityInpuitModel : BaseInputModel
        where TEntity : BaseEntity
        where TEntityViewModel: BaseViewModel
    {
        protected readonly IBaseService<TEntityInpuitModel, TEntity, TEntityViewModel> _service;

        protected EntityController(IBaseService<TEntityInpuitModel, TEntity, TEntityViewModel> service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"{typeof(TEntity).Name} with id {id} not found");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TEntityInpuitModel inputModel, int id)
        {
            try
            {
                if (inputModel != null)
                {
                    var result = await _service.Update(inputModel, id);
                    if (result != null)
                    {
                        return Ok(result);
                    }

                    return NotFound($"{typeof(TEntity).Name} with id {id} not found");
                }

                return BadRequest("Invalid input model");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Invalid values from input model");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Remove(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"{typeof(TEntity).Name} with id {id} not found");
        }
    }
}
