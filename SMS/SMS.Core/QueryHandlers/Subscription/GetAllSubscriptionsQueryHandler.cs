using AutoMapper;
using MediatR;
using SMS.Core.Models.ViewModels;
using SMS.Core.Queries.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;
using SMS.Domain.Results.Errors;

namespace SMS.Core.QueryHandlers.Subscription
{
    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, Result<IEnumerable<SubscriptionViewModel>>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public GetAllSubscriptionsQueryHandler(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SubscriptionViewModel>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionsAsync(data => data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                return Result<IEnumerable<SubscriptionViewModel>>.Failure(SubscriptionErros.NULL);

            var dto = _mapper.Map<IEnumerable<SubscriptionViewModel>>(result);
            return Result<IEnumerable<SubscriptionViewModel>>.Success(dto);
        }
    }
}
