using MediatR;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Subscription
{
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionViewModel>>
    {
        public GetSubscriptionByIdQuery(Guid id) =>
            Id = id;

        public Guid Id { get; init; }
    }
}
