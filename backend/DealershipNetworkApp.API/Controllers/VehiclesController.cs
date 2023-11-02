using DealershipNetworkApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehiclesController(IVehicleService service)
            => _service = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicles = _service.GetAll();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _service.GetById(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            return NotFound();
        }
    }
}
