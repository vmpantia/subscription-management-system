using AutoMapper;
using SMS.Core.Models.ViewModels.Product;
using SMS.Domain.Models.Entities;

namespace SMS.Core.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.ProductGroupName, opt => opt.MapFrom(src => src.ProductGroup.Name))
                .ForMember(dst => dst.ProductTypeName, opt => opt.MapFrom(src => src.ProductGroup.ProductType.Name));
            CreateMap<Product, ProductLiteViewModel>();
        }
    }
}
