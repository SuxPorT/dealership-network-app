using DealershipNetworkApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _service;

        public SellersController(ISellerService service)
            => _service = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            var sellers = _service.GetAll();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var seller = _service.GetById(id);
            if (seller != null)
            {
                return Ok(seller);
            }

            return NotFound();
        }
    }
}
