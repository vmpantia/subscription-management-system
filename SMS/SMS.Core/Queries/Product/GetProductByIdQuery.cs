using MediatR;
using SMS.Core.Models.ViewModels.Product;
using SMS.Domain.Results;

namespace SMS.Core.Queries.Product
{
    public class GetProductByIdQuery : IRequest<Result<ProductViewModel>>
    {
        public GetProductByIdQuery(Guid id) =>
            Id = id;

        public Guid Id { get; init; }
    }
}
