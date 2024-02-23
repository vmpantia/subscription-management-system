using AutoMapper;
using MediatR;
using SMS.Core.Commands.Product;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;
using SMS.Domain.Results.Errors;

namespace SMS.Core.CommandHandlers
{
    public class ProductCommandHandlers : IRequestHandler<AddProductCommand, Result<string>>
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public ProductCommandHandlers(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);

            if (newProduct is null)
                return Result<string>.Failure(CommonErrors.NullValue(nameof(Product)));

            newProduct.Status = CommonStatus.Active;
            newProduct.CreatedAt = DateTime.Now;
            newProduct.CreatedBy = request.Requestor;

            var result = await _product.AddProductAsync(newProduct);

            return Result<string>.Success($"Product added successfully. {result.Id}");
        }
    }
}
