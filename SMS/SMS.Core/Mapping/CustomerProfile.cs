using AutoMapper;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Domain.Models.Entities;

namespace SMS.Core.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Subscription, CustomerSubscriptionViewModel>()
                .ForMember(dst => dst.Total, opt => opt.MapFrom(src => src.Quantity * src.UnitPrice))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.ProductVendor, opt => opt.MapFrom(src => src.Product.Vendor))
                .ForMember(dst => dst.ProductManufacturer, opt => opt.MapFrom(src => src.Product.Manufacturer))
                .ForMember(dst => dst.ProductGroupName, opt => opt.MapFrom(src => src.Product.ProductGroup.Name))
                .ForMember(dst => dst.ProductTypeName, opt => opt.MapFrom(src => src.Product.ProductGroup.ProductType.Name))
                .ForMember(dst => dst.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dst => dst.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dst => dst.CustomerCurrency, opt => opt.MapFrom(src => src.Customer.Currency))
                .ForMember(dst => dst.CustomerBillerId, opt => opt.MapFrom(src => src.Customer.BillToCustomer.Id))
                .ForMember(dst => dst.CustomerBillerName, opt => opt.MapFrom(src => src.Customer.BillToCustomer.Name))
                .ForMember(dst => dst.CustomerBillerCurrency, opt => opt.MapFrom(src => src.Customer.BillToCustomer.Currency));
        }
    }
}
