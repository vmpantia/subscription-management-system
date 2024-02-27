using MediatR;
using SMS.Core.Models.Dtos.Subscription;
using SMS.Domain.Models.Entities;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Subscription
{
    public class UpdateSubscriptionCommand : CreateSubscriptionCommand, IRequest<Result<string>>
    {
        public UpdateSubscriptionCommand(Guid subscriptionId, UpdateSubscriptionDto request, string requestor) : base(request, requestor)
        {
            SubscriptionId = subscriptionId;
            ProductId = request.ProductId;
            Name = request.Name;
            Description = request.Description;
            Quantity = request.Quantity;
            UnitPrice = request.UnitPrice;
            AnnivesaryDate = request.AnnivesaryDate;
            ServicePeriodStartAt = request.ServicePeriodStartAt;
            ServicePeriodEndAt = request.ServicePeriodEndAt;
            ActivationDate = request.ActivationDate;
            IsAutomaticRenewal = request.IsAutomaticRenewal;
            PaymentCycle = request.PaymentCycle;
            SubscriptionCycle = request.SubscriptionCycle;
            Requestor = requestor;
        }

        public Guid SubscriptionId { get; init; }
    }
}
