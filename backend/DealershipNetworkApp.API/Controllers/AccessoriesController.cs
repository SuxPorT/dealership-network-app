using DealershipNetworkApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : ControllerBase
    {
        private readonly IAccessoryService _service;

        public AccessoriesController(IAccessoryService service)
            => _service = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            var accessories = _service.GetAll();
            return Ok(accessories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var accessory = _service.GetById(id);
            if (accessory != null)
            {
                return Ok(accessory);
            }

            return NotFound();
        }
    }
}
