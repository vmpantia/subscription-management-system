using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            await HandleRequestAsync(new GetAllSubscriptionsQuery());

        [HttpGet("lites")]
        public async Task<IActionResult> GetAllSubscriptionLitesAsync() =>
            await HandleRequestAsync(new GetAllSubscriptionLitesQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionAsync(Guid id) =>
            await HandleRequestAsync(new GetSubscriptionByIdQuery(id));
    }
}