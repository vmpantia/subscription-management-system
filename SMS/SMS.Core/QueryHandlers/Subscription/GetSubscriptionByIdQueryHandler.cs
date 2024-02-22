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
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<Result<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionAsync(data => data.Id == request.Id &&
                                                                          data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                return Result<SubscriptionViewModel>.Failure(SubscriptionErros.NotFound(request.Id));

            var dto = _mapper.Map<SubscriptionViewModel>(result);
            return Result<SubscriptionViewModel>.Success(dto);
        }
    }
}
