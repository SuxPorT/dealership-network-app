using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.Interfaces.Services;
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
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Phone phone)
        {
            if (phone != null)
            {
                var result = _service.Add(phone);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] Phone phone, int id)
        {
            if (phone != null)
            {
                var result = _service.Update(phone, id);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = GetById(id);
            if (result != null)
            {
                var deleted = _service.Remove(id);
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
