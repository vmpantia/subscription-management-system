using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Commands.Subscription;
using SMS.Core.Models.Dtos.Subscription;
using SMS.Core.Models.ViewModels.Subscription;
using SMS.Core.Queries.Subscription;
using SMS.WebApi.Common;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("subscriptions")]
    public class SubscriptionController : BaseController
    {
        public SubscriptionController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionsAsync() =>
            await HandleRequestAsync<GetAllSubscriptionsQuery, IEnumerable<SubscriptionViewModel>>(new GetAllSubscriptionsQuery());

        [HttpGet("lites")]
        public async Task<IActionResult> GetAllSubscriptionLitesAsync() =>
            await HandleRequestAsync<GetAllSubscriptionLitesQuery, IEnumerable<SubscriptionLiteViewModel>>(new GetAllSubscriptionLitesQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionAsync(Guid id) =>
            await HandleRequestAsync<GetSubscriptionByIdQuery, SubscriptionViewModel>(new GetSubscriptionByIdQuery(id));

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateSubscriptionDto request) =>
            await HandleRequestAsync<CreateSubscriptionCommand, string>(new CreateSubscriptionCommand(request, string.Empty));

        [HttpPut("{subscriptionId}")]
        public async Task<IActionResult> UpdateProductAsync(Guid subscriptionId, [FromForm] UpdateSubscriptionDto request) =>
            await HandleRequestAsync<UpdateSubscriptionCommand, string>(new UpdateSubscriptionCommand(subscriptionId, request, string.Empty));

        [HttpPatch("{subscriptionId}")]
        public async Task<IActionResult> UpdateProductStatusAsync(Guid subscriptionId, [FromForm] UpdateSubscriptionStatusDto request) =>
            await HandleRequestAsync<UpdateSubscriptionStatusCommand, string>(new UpdateSubscriptionStatusCommand(subscriptionId, request, string.Empty));
    }
}