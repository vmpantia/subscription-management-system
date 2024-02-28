using MediatR;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Customer
{
    public sealed record GetCustomerNameByIdQuery(Guid CustomerId) : IRequest<Result<string>> { }
}
