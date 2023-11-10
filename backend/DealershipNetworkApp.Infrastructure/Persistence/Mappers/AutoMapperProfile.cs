using AutoMapper;
using DealershipNetworkApp.Core.InputModels;
using DealershipNetworkApp.Core.Entities;
using DealershipNetworkApp.Core.ViewModel;

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

            CreateMap<Accessory, AccessoryViewModel>();
            CreateMap<Owner, OwnerViewlModel>();
            CreateMap<Phone, PhoneViewModel>();
            CreateMap<Sale, SaleViewModel>();
            CreateMap<Seller, SellerViewModel>();
            CreateMap<Vehicle, VehicleViewModel>();
        }
    }
}
