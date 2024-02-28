using AutoMapper;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Core.Queries.Subscription;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Results.Errors;
using SMS.Domain.Results;
using MediatR;
using SMS.Domain.Models.Enums;

namespace SMS.Core.QueryHandlers
{
    public class SubscriptionQueryHandlers : 
        IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public SubscriptionQueryHandlers(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<Result<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionFullInfoAsync(data => data.Id == request.SubscriptionId &&
                                                                                  data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                return Result<SubscriptionViewModel>.Failure(SubscriptionErrors.NotFound(request.SubscriptionId));

            var data = _mapper.Map<SubscriptionViewModel>(result);
            return Result<SubscriptionViewModel>.Success(data);
        }
    }
}
