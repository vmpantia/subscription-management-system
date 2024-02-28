using MediatR;
using SMS.Core.Models.Dtos.Subscription;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Subscription
{
    public class CreateSubscriptionCommand : IRequest<Result<string>>
    {
        public CreateSubscriptionCommand(CreateSubscriptionDto request, string requestor)
        {
            ProductId = request.ProductId;
            Name = request.Name;
            Description = request.Description;
            Quantity = request.Quantity;
            UnitPrice = request.UnitPrice;
            AnniversaryDate = request.AnniversaryDate;
            ServicePeriodStartAt = request.ServicePeriodStartAt;
            ServicePeriodEndAt = request.ServicePeriodEndAt;
            ActivationDate = request.ActivationDate;
            IsAutomaticRenewal = request.IsAutomaticRenewal;
            PaymentCycle = request.PaymentCycle;
            SubscriptionCycle = request.SubscriptionCycle;
            Requestor = requestor;
        }

        public Guid ProductId { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
        public DateTime AnniversaryDate { get; init; }
        public DateTime ServicePeriodStartAt { get; init; }
        public DateTime ServicePeriodEndAt { get; init; }
        public DateTime ActivationDate { get; init; }
        public bool IsAutomaticRenewal { get; init; }
        public string PaymentCycle { get; init; }
        public string SubscriptionCycle { get; init; }
        public string Requestor { get; init; }
    }
}
