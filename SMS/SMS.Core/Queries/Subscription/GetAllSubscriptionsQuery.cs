using MediatR;
using SMS.Core.Models;

namespace SMS.Core.Queries.Subscription
{
    public class GetAllSubscriptionsQuery : IRequest<IEnumerable<SubscriptionViewModel>> { }
}
