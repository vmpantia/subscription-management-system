using AutoMapper;
using MediatR;
using SMS.Core.Models.ViewModels;
using SMS.Core.Queries.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Enums;

namespace SMS.Core.QueryHandlers.Subscription
{
    public class GetAllSubscriptionLitesQueryHandler : IRequestHandler<GetAllSubscriptionLitesQuery, IEnumerable<SubscriptionLiteViewModel>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public GetAllSubscriptionLitesQueryHandler(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionLiteViewModel>> Handle(GetAllSubscriptionLitesQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionsAsync(data => data.Status == SubscriptionStatus.Active);
            return _mapper.Map<IEnumerable<SubscriptionLiteViewModel>>(result);
        }
    }
}
