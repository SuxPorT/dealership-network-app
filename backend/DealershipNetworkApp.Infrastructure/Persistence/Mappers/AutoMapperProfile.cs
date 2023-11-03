using AutoMapper;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Infrastructure.Persistence.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccessoryInputModel, Accessory>();
            CreateMap<OwnerInputModel, Owner>();
            CreateMap<PhoneInputModel, Phone>();
            CreateMap<SaleInputModel, Sale>();
            CreateMap<SellerInputModel, Seller>();
            CreateMap<VehicleInputModel, Vehicle>();
        }
    }
}
