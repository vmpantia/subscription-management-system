using MediatR;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Subscription
{
    public class GetAllSubscriptionsQuery : IRequest<Result<IEnumerable<SubscriptionViewModel>>> { }
}
