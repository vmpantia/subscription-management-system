using MediatR;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Customer
{
    public sealed record GetCustomerBillingSubscriptionsByIdQuery(Guid CustomerId) : IRequest<Result<IEnumerable<CustomerSubscriptionViewModel>>> { }
}
