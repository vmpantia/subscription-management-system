using MediatR;
using SMS.Core.Models.ViewModels.Customer;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Customer
{
    public class GetAllCustomersQuery : IRequest<Result<IEnumerable<CustomerViewModel>>> { }
}
