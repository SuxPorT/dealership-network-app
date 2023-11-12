using Autofac.Core;
using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : EntityController<PhoneInputModel, Phone, PhoneViewModel>
    {
        public PhonesController(IPhoneService service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhoneInputModel inputModel)
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
    }
}
