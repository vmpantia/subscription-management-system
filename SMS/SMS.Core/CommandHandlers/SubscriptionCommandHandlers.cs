using AutoMapper;
using MediatR;
using SMS.Core.Commands.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;
using SMS.Domain.Results.Errors;

namespace SMS.Core.CommandHandlers
{
    public class SubscriptionCommandHandlers :
        IRequestHandler<CreateSubscriptionCommand, Result<string>>,
        IRequestHandler<UpdateSubscriptionCommand, Result<string>>,
        IRequestHandler<UpdateSubscriptionStatusCommand, Result<string>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public SubscriptionCommandHandlers(ISubscriptionRepository subscription, IProductRepository product, IMapper mapper)
        {
            _subscription = subscription;
            _product = product;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            // Convert request to subscription
            var newSubscription = _mapper.Map<Subscription>(request);

            // Check if the newProduct is NULL
            if (newSubscription is null)
                return Result<string>.Failure(SubscriptionErrors.NullValue);

            // Check if the product id is exist on the database
            if (await _product.IsExistAsync(data => data.Id == request.ProductId && data.Status != CommonStatus.Deleted))
                return Result<string>.Failure(ProductErrors.NotFound(request.ProductId));

            // Set other information
            newSubscription.Status = SubscriptionStatus.Active;
            newSubscription.CreatedAt = DateTime.Now;
            newSubscription.CreatedBy = request.Requestor;

            // Create & save new product
            var result = await _subscription.CreateSubscriptionAsync(newSubscription);

            return Result<string>.Success($"Subscription created successfully. {result.Id}");
        }

        public async Task<Result<string>> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            // Get subscription to be edit using subscriptionId
            var currentSubscription = await _subscription.GetSubscriptionAsync(data => data.Id == request.SubscriptionId);

            // Check if the subscription to be edit is existing
            if (currentSubscription is null)
                return Result<string>.Failure(SubscriptionErrors.NotFound(request.ProductId));

            // Check if the subscription to be edit is already deleted
            if (currentSubscription.Status == SubscriptionStatus.Deleted)
                return Result<string>.Failure(SubscriptionErrors.AlreadyDeleted);

            // Check if the product id is exist on the database
            if (await _product.IsExistAsync(data => data.Id == request.ProductId && data.Status != CommonStatus.Deleted))
                return Result<string>.Failure(ProductErrors.NotFound(request.ProductId));

            // Get updated subscription information
            var updatedSubscription = _mapper.Map(request, currentSubscription);
            updatedSubscription.UpdatedAt = DateTime.Now;
            updatedSubscription.UpdatedBy = request.Requestor;

            // Update & save subscription
            var result = await _subscription.UpdateSubscriptionAsync(updatedSubscription);

            return Result<string>.Success($"Subscription updated successfully. {request.ProductId}");
        }

        public async Task<Result<string>> Handle(UpdateSubscriptionStatusCommand request, CancellationToken cancellationToken)
        {
            // Get subscription to be edit using productId
            var currentSubscription = await _subscription.GetSubscriptionAsync(data => data.Id == request.SubscriptionId);

            // Check if the subscription to be edit is existing
            if (currentSubscription is null)
                return Result<string>.Failure(SubscriptionErrors.NotFound(request.SubscriptionId));

            // Check if the subscription to be edit is already deleted
            if (currentSubscription.Status == SubscriptionStatus.Deleted)
                return Result<string>.Failure(SubscriptionErrors.AlreadyDeleted);

            // Update subscription status
            currentSubscription.Status = request.NewStatus;
            currentSubscription.UpdatedAt = DateTime.Now;
            currentSubscription.UpdatedBy = request.Requestor;

            // Edit & save subscription
            var result = await _subscription.UpdateSubscriptionAsync(currentSubscription);

            return Result<string>.Success($"Subscription status updated successfully. {request.SubscriptionId}");
        }
    }
}
