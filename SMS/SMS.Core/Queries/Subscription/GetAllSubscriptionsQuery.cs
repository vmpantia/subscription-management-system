using MediatR;
using SMS.Core.Models.ViewModels;

namespace SMS.Core.Queries.Subscription
{
    public class GetAllSubscriptionsQuery : IRequest<IEnumerable<SubscriptionViewModel>> { }
}
