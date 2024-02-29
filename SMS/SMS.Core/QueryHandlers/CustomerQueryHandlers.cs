using AutoMapper;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Results.Errors;
using SMS.Domain.Results;
using MediatR;
using SMS.Domain.Models.Enums;
using SMS.Core.Queries.Customer;
using SMS.Core.Models.ViewModels.Customer;

namespace SMS.Core.QueryHandlers
{
    public class CustomerQueryHandlers : 
        IRequestHandler<GetCustomerSubscriptionsByIdQuery, Result<IEnumerable<CustomerSubscriptionViewModel>>>,
        IRequestHandler<GetCustomerBillingSubscriptionsByIdQuery, Result<IEnumerable<CustomerSubscriptionViewModel>>>,
        IRequestHandler<GetCustomerNameByIdQuery, Result<string>>
    {
        private readonly ICustomerRepository _customer;
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public CustomerQueryHandlers(ICustomerRepository customer, ISubscriptionRepository subscription, IMapper mapper)
        {
            _customer = customer;
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CustomerSubscriptionViewModel>>> Handle(GetCustomerSubscriptionsByIdQuery request, CancellationToken cancellationToken)
        {
            // Check if the customer exist in the database
            if(!await _customer.IsExistAsync(data => data.Id == request.CustomerId &&
                                                     data.Status == CommonStatus.Active))
                return Result<IEnumerable<CustomerSubscriptionViewModel>>.Failure(CustomerErrors.NotFound(request.CustomerId));

            // Get customer subscriptions in the database
            var result = await _subscription.GetSubscriptionsFullInfoAsync(data => data.CustomerId == request.CustomerId && 
                                                                                   data.Status != SubscriptionStatus.Deleted);

            // Check if subscription or result is NULL
            if (result is null)
                return Result<IEnumerable<CustomerSubscriptionViewModel>>.Failure(SubscriptionErrors.NullValue);

            // Convert result to view model
            var data = _mapper.Map<IEnumerable<CustomerSubscriptionViewModel>>(result);
            return Result<IEnumerable<CustomerSubscriptionViewModel>>.Success(data);
        }

        public async Task<Result<IEnumerable<CustomerSubscriptionViewModel>>> Handle(GetCustomerBillingSubscriptionsByIdQuery request, CancellationToken cancellationToken)
        {
            // Check if the customer exist in the database
            if (!await _customer.IsExistAsync(data => data.Id == request.CustomerId &&
                                                      data.Status == CommonStatus.Active))
                return Result<IEnumerable<CustomerSubscriptionViewModel>>.Failure(CustomerErrors.NotFound(request.CustomerId));

            // Get customer billing subscriptions in the database
            var result = await _subscription.GetSubscriptionsFullInfoAsync(data => data.Customer.BillToCustomerId == request.CustomerId &&
                                                                                   data.Status != SubscriptionStatus.Deleted);

            // Check if subscription or result is NULL
            if (result is null)
                return Result<IEnumerable<CustomerSubscriptionViewModel>>.Failure(SubscriptionErrors.NullValue);

            // Convert result to view model
            var data = _mapper.Map<IEnumerable<CustomerSubscriptionViewModel>>(result);
            return Result<IEnumerable<CustomerSubscriptionViewModel>>.Success(data);
        }

        public async Task<Result<string>> Handle(GetCustomerNameByIdQuery request, CancellationToken cancellationToken)
        {
            // Check if the customer exist in the database
            var result = await _customer.GetCustomerAsync(data => data.Id == request.CustomerId &&
                                                                  data.Status == CommonStatus.Active);

            // Check if customer or result is NULL
            if (result is null)  
                return Result<string>.Failure(CustomerErrors.NotFound(request.CustomerId));

            return Result<string>.Success($"{result.Name} ({result.ShortName})");
        }
    }
}
