using AutoMapper;
using SMS.Core.Commands.Product;
using SMS.Core.Models.Dtos;
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
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Status, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore());
        }
    }
}
