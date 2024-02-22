using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Models.ViewModels;
using SMS.Core.Queries.Subscription;
using SMS.WebApi.Common;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("subscriptions")]
    public class SubscriptionController : BaseController
    {
        public SubscriptionController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionsAsync() =>
            await HandleRequestAsync<GetAllSubscriptionsQuery, IEnumerable<SubscriptionViewModel>>(new GetAllSubscriptionsQuery());

        [HttpGet("lites")]
        public async Task<IActionResult> GetAllSubscriptionLitesAsync() =>
            await HandleRequestAsync<GetAllSubscriptionLitesQuery, IEnumerable<SubscriptionLiteViewModel>>(new GetAllSubscriptionLitesQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionAsync(Guid id) =>
            await HandleRequestAsync<GetSubscriptionByIdQuery, SubscriptionViewModel>(new GetSubscriptionByIdQuery(id));
    }
}