using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Core.Queries.Customer;
using SMS.WebApi.Common;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator) { }

        [HttpGet("{customerId}/subscriptions")]
        public async Task<IActionResult> GetCustomerSubscriptions(Guid customerId) =>
            await HandleRequestAsync<GetCustomerSubscriptionsQuery, IEnumerable<CustomerSubscriptionViewModel>>(new GetCustomerSubscriptionsQuery(customerId));
    }
}