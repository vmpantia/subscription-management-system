using MediatR;
using SMS.Core.Models.Dtos.Subscription;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Subscription
{
    public class UpdateSubscriptionStatusCommand : IRequest<Result<string>>
    {
        public UpdateSubscriptionStatusCommand(Guid subscriptionId, UpdateSubscriptionStatusDto request, string requestor)
        {
            SubscriptionId = subscriptionId;
            NewStatus = request.NewStatus;
            Requestor = requestor;
        }

        public Guid SubscriptionId { get; init; }
        public SubscriptionStatus NewStatus { get; init; }
        public string Requestor { get; init; }
    }
}
