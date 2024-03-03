using AutoMapper;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;

namespace SMS.Core.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => $"{src.Name} ({src.ShortName})"))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dst => dst.BillToCustomerId, opt => opt.MapFrom(src => src.BillToCustomer.Id))
                .ForMember(dst => dst.BillToCustomerName, opt => opt.MapFrom(src => src.BillToCustomer == null ? null : $"{src.BillToCustomer.Name} ({src.BillToCustomer.ShortName})"))
                .ForMember(dst => dst.BillToCustomerCurrency, opt => opt.MapFrom(src => src.BillToCustomer.Currency))
                .ForMember(dst => dst.NoOfSubscriptions, opt => opt.MapFrom(src => src.Subscriptions.Count(data => data.Status != SubscriptionStatus.Deleted)));

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
                .ForMember(dst => dst.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.Name} ({src.Customer.ShortName})"))
                .ForMember(dst => dst.CustomerCurrency, opt => opt.MapFrom(src => src.Customer.Currency))
                .ForMember(dst => dst.BillToCustomerId, opt => opt.MapFrom(src => src.Customer.BillToCustomer.Id))
                .ForMember(dst => dst.BillToCustomerName, opt => opt.MapFrom(src => src.Customer.BillToCustomer == null ? null : $"{src.Customer.BillToCustomer.Name} ({src.Customer.BillToCustomer.ShortName})"))
                .ForMember(dst => dst.BillToCustomerCurrency, opt => opt.MapFrom(src => src.Customer.BillToCustomer.Currency));
        }
    }
}
