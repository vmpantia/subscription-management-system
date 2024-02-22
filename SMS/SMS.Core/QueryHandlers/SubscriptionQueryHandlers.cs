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
        IRequestHandler<GetAllSubscriptionLitesQuery, Result<IEnumerable<SubscriptionLiteViewModel>>>,
        IRequestHandler<GetAllSubscriptionsQuery, Result<IEnumerable<SubscriptionViewModel>>>,
        IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscription;
        private readonly IMapper _mapper;
        public SubscriptionQueryHandlers(ISubscriptionRepository subscription, IMapper mapper)
        {
            _subscription = subscription;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SubscriptionLiteViewModel>>> Handle(GetAllSubscriptionLitesQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionsAsync(data => data.Status == SubscriptionStatus.Active);

            if (result is null)
                return Result<IEnumerable<SubscriptionLiteViewModel>>.Failure(SubscriptionErros.NULL);

            var dto = _mapper.Map<IEnumerable<SubscriptionLiteViewModel>>(result);
            return Result<IEnumerable<SubscriptionLiteViewModel>>.Success(dto);
        }

        public async Task<Result<IEnumerable<SubscriptionViewModel>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionsFullInfoAsync(data => data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                return Result<IEnumerable<SubscriptionViewModel>>.Failure(SubscriptionErros.NULL);

            var dto = _mapper.Map<IEnumerable<SubscriptionViewModel>>(result);
            return Result<IEnumerable<SubscriptionViewModel>>.Success(dto);
        }

        public async Task<Result<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _subscription.GetSubscriptionFullInfoAsync(data => data.Id == request.Id &&
                                                                                  data.Status != SubscriptionStatus.Deleted);

            if (result is null)
                return Result<SubscriptionViewModel>.Failure(SubscriptionErros.NotFound(request.Id));

            var dto = _mapper.Map<SubscriptionViewModel>(result);
            return Result<SubscriptionViewModel>.Success(dto);
        }
    }
}
