using AutoMapper;
using SMS.Core.Commands.Subscription;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Domain.Models.Entities;

namespace SMS.Core.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(dst => dst.Total, opt => opt.MapFrom(src => src.Quantity * src.UnitPrice))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.ProductVendor, opt => opt.MapFrom(src => src.Product.Vendor))
                .ForMember(dst => dst.ProductManufacturer, opt => opt.MapFrom(src => src.Product.Manufacturer))
                .ForMember(dst => dst.ProductGroupName, opt => opt.MapFrom(src => src.Product.ProductGroup.Name))
                .ForMember(dst => dst.ProductTypeName, opt => opt.MapFrom(src => src.Product.ProductGroup.ProductType.Name));
            CreateMap<CreateSubscriptionCommand, Subscription>();
        }
    }
}
