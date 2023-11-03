using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IPhoneService _service;

        public PhonesController(IPhoneService service)
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

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhoneInputModel phoneInputModel)
        {
            if (phoneInputModel != null)
            {
                var result = await _service.Add(phoneInputModel);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Create([FromBody] PhoneInputModel phoneInputModel, int id)
        {
            if (phoneInputModel != null)
            {
                var result = await _service.Update(phoneInputModel, id);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                var deleted = await _service.Remove(id);
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
