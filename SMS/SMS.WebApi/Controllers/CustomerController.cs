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

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() =>
            await HandleRequestAsync<GetAllCustomersQuery, IEnumerable<CustomerViewModel>>(new GetAllCustomersQuery());

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId) =>
            await HandleRequestAsync<GetCustomerByIdQuery, CustomerViewModel>(new GetCustomerByIdQuery(customerId));

        [HttpGet("{customerId}/subscriptions")]
        public async Task<IActionResult> GetCustomerSubscriptions(Guid customerId) =>
            await HandleRequestAsync<GetCustomerSubscriptionsByIdQuery, IEnumerable<CustomerSubscriptionViewModel>>(new GetCustomerSubscriptionsByIdQuery(customerId));

        [HttpGet("{customerId}/billing-subscriptions")]
        public async Task<IActionResult> GetCustomerBillingSubscriptions(Guid customerId) =>
            await HandleRequestAsync<GetCustomerBillingSubscriptionsByIdQuery, IEnumerable<CustomerSubscriptionViewModel>>(new GetCustomerBillingSubscriptionsByIdQuery(customerId));
    }
}