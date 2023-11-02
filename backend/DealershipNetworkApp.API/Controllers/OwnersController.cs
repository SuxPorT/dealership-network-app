using DealershipNetworkApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnersController(IOwnerService service)
            => _service = service;

        [HttpGet]
        public IActionResult GetAll() 
        {
            var owners = _service.GetAll();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var owner = _service.GetById(id);
            if (owner != null)
            {
                return Ok(owner);
            }

            return NotFound();
        }
    }
}
