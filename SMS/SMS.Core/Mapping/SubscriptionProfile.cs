using AutoMapper;
using SMS.Core.Models.ViewModels;
using SMS.Domain.Models.Entities;

namespace SMS.Core.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<Subscription, SubscriptionLiteViewModel>();
        }
    }
}
