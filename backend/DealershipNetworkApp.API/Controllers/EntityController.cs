using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.API.Controllers
{
    public abstract class EntityController<TEntityInpuitModel, TEntity> : ControllerBase
        where TEntityInpuitModel : BaseInputModel
        where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntityInpuitModel, TEntity> _service;

        protected EntityController(IBaseService<TEntityInpuitModel, TEntity> service)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntityInpuitModel inputModel)
        {
            try
            {
                if (inputModel != null)
                {
                    var result = await _service.Add(inputModel);
                    return Ok(result);
                }

                return BadRequest("Invalid input model");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Invalid values from input model");
            }
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
            var result = await _service.GetById(id);
            if (result != null)
            {
                var deleted = await _service.Remove(result);
                return Ok(deleted);
            }

            return NotFound($"{typeof(TEntity).Name} with id {id} not found");
        }
    }
}
