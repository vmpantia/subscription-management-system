using MediatR;
using SMS.Core.Models.ViewModels;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Subscription
{
    public class GetAllSubscriptionLitesQuery : IRequest<Result<IEnumerable<SubscriptionLiteViewModel>>> { }
}
