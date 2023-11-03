using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : EntityController<SaleInputModel, Sale>
    {
        public SalesController(ISaleService service) : base(service) { }
    }
}
