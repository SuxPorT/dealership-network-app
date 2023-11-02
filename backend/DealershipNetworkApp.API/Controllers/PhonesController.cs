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
            var phones = _service.GetAll();
            return Ok(phones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var phone = _service.GetById(id);
            if (phone != null)
            {
                return Ok(phone);
            }

            return NotFound();
        }
    }
}
