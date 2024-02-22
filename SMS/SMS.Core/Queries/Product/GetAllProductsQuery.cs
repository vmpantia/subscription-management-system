using MediatR;
using SMS.Core.Models.ViewModels.Product;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Product
{
    public class GetAllProductsQuery : IRequest<Result<IEnumerable<ProductViewModel>>> { }
}
