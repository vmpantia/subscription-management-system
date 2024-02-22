using AutoMapper;
using SMS.Core.Models.ViewModels.Product;
using SMS.Core.Queries.Product;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Results.Errors;
using SMS.Domain.Results;
using MediatR;
using SMS.Domain.Models.Enums;

namespace SMS.Core.QueryHandlers
{
    public class ProductQueryHandlers : IRequestHandler<GetAllProductQuery, Result<IEnumerable<ProductViewModel>>>
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public ProductQueryHandlers(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductViewModel>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _product.GetProductsFullInfoAsync(data => data.Status != CommonStatus.Deleted);

            if (result is null)
                return Result<IEnumerable<ProductViewModel>>.Failure(ProductErrors.NULL);

            var dto = _mapper.Map<IEnumerable<ProductViewModel>>(result);
            return Result<IEnumerable<ProductViewModel>>.Success(dto);
        }
    }
}
