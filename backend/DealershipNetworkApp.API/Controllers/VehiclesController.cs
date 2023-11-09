using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByChassis/{chassisNumber}")]
        public async Task<IActionResult> GetByChassisNumber(string chassisNumber)
        {
            var result = await _service.GetByChassisNumber(chassisNumber);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"Vehicle with chassis number {chassisNumber} not found");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleInputModel inputModel)
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

        [HttpPut("UpdadeByChassis/{chassisNumber}")]
        public async Task<IActionResult> UpdateChassisNumber([FromBody] VehicleInputModel inputModel, string chassisNumber)
        {
            try
            {
                if (inputModel != null)
                {
                    var result = await _service.UpdateByChassisNumber(inputModel, chassisNumber);
                    if (result != null)
                    {
                        return Ok(result);
                    }

                    return NotFound($"Vehicle with chassis number {chassisNumber} not found");
                }

                return BadRequest("Invalid input model");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Invalid values from input model");
            }
        }

        [HttpDelete("DeleteByChassis/{chassisNumber}")]
        public async Task<IActionResult> DeleteByCpfCnpj(string chassisNumber)
        {
            var result = await _service.GetByChassisNumber(chassisNumber);
            if (result != null)
            {
                var deleted = await _service.RemoveByChassisNumber(result);
                return Ok(deleted);
            }

            return NotFound($"Vehicle with chassis number {chassisNumber} not found");
        }
    }
}
