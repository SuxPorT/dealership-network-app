using DealershipNetworkApp.Application.Interfaces.Services;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DealershipNetworkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController 
        : EntityController<AccessoryInputModel, Accessory, AccessoryViewModel>
    {
        public AccessoriesController(IAccessoryService service) : base(service) { }
    }
}
