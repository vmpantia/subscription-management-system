using MediatR;
using SMS.Core.Models.ViewModels;

namespace SMS.Core.Queries.Subscription
{
    public class GetSubscriptionByIdQuery : IRequest<SubscriptionViewModel>
    {
        public GetSubscriptionByIdQuery(Guid id) =>
            Id = id;

        public Guid Id { get; init; }
    }
}
