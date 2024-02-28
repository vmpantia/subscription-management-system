using MediatR;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Subscription
{
    public sealed record GetSubscriptionByIdQuery(Guid SubscriptionId) : IRequest<Result<SubscriptionViewModel>> { }
}
