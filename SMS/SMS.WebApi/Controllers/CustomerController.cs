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
            await HandleRequestAsync<GetCustomerSubscriptionsByIdQuery, IEnumerable<CustomerSubscriptionViewModel>>(new GetCustomerSubscriptionsByIdQuery(customerId));
        
        [HttpGet("{customerId}/name")]
        public async Task<IActionResult> GetCustomerName(Guid customerId) =>
            await HandleRequestAsync<GetCustomerNameByIdQuery, string>(new GetCustomerNameByIdQuery(customerId));
    }
}