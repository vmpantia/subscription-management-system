using MediatR;
using SMS.Core.Models.ViewModels.Product;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Product
{
    public class GetAllProductLitesQuery : IRequest<Result<IEnumerable<ProductLiteViewModel>>> { }
}
