using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Queries.Subscription;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionsAsync()
        {
            var result = await _mediator.Send(new GetAllSubscriptionsQuery());
            return Ok(result);
        }
    }
}