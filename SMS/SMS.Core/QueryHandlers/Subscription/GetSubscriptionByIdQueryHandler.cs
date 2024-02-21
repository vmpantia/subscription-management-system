using AutoMapper;
using MediatR;
using SMS.Core.Models.ViewModels;
using SMS.Core.Queries.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Exceptions;
using SMS.Domain.Models.Enums;

namespace SMS.Core.QueryHandlers.Subscription
{
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionViewModel>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<SubscriptionViewModel> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionAsync(data => data.Id == request.Id &&
                                                                          data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                throw new DataNotFoundException($"Subscription with an Id {request.Id} is NOT found on the database.");

            return _mapper.Map<SubscriptionViewModel>(result);
        }
    }
}
