using MediatR;
using SMS.Core.Models;
using SMS.Core.Queries.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Enums;

namespace SMS.Core.QueryHandlers.Subscription
{
    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, IEnumerable<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscription;
        public GetAllSubscriptionsQueryHandler(ISubscriptionRepository subscription)
        {
            _subscription = subscription;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionsAsync(data => data.Status != SubscriptionStatus.Deleted);

            return result.Select(data => new SubscriptionViewModel { Id = data.Id });
        }
    }
}
