using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : EntityController<OwnerInputModel, Owner>
    {
        private readonly IOwnerService _service;

        public OwnersController(IOwnerService service) : base(service)
            => _service = service;

        [HttpGet("GetByCpfCnpj/{cpfCnpj}")]
        public async Task<IActionResult> GetByCpfCnpj(string cpfCnpj)
        {
            var result = await _service.GetByCpfCnpj(cpfCnpj);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"Owner with CPF/CNPJ {cpfCnpj} not found");
        }

        [HttpPut("UpdateByCpfCnpj/{cpfCnpj}")]
        public async Task<IActionResult> UpdateByCpfCnpj([FromBody] OwnerInputModel inputModel, string cpfCnpj)
        {
            try
            {
                if (inputModel != null)
                {
                    var result = await _service.UpdateByCpfCnpj(inputModel, cpfCnpj);
                    if (result != null)
                    {
                        return Ok(result);
                    }

                    return NotFound($"Owner with CPF/CNPJ {cpfCnpj} not found");
                }

                return BadRequest("Invalid input model");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Invalid values from input model");
            }
        }

        [HttpDelete("DeleteByCpfCnpj/{cpfCnpj}")]
        public async Task<IActionResult> DeleteByCpfCnpj(string cpfCnpj)
        {
            var result = await _service.GetByCpfCnpj(cpfCnpj);
            if (result != null)
            {
                var deleted = await _service.Remove(result.Id);
                return Ok(deleted);
            }

            return NotFound($"Owner with CPF/CNPJ {cpfCnpj} not found");
        }
    }
}
