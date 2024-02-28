using MediatR;
using SMS.Core.Models.ViewModels.Product;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Product
{
    public sealed record GetProductByIdQuery(Guid ProductId) : IRequest<Result<ProductViewModel>> { }
}
