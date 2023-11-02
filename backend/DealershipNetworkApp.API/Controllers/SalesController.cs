using DealershipNetworkApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _service;

        public SalesController(ISaleService service)
            => _service = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            var sales = _service.GetAll();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sale = _service.GetById(id);
            if (sale != null)
            {
                return Ok(sale);
            }

            return NotFound();
        }
    }
}
