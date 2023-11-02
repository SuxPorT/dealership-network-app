using DealershipNetworkApp.Core.Entities;
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
        public IActionResult Create([FromBody] Seller seller)
        {
            if (seller != null)
            {
                var result = _service.Add(seller);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] Seller seller, int id)
        {
            if (seller != null)
            {
                var result = _service.Update(seller, id);
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
