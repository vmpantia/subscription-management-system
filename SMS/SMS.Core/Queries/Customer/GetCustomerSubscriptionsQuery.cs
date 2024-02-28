using MediatR;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Customer
{
    public sealed record GetCustomerSubscriptionsQuery(Guid CustomerId) : IRequest<Result<IEnumerable<CustomerSubscriptionViewModel>>> { }
}
