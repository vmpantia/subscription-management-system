using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using SMS.Core.Commands.Product;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;
using SMS.Domain.Results.Errors;

namespace SMS.Core.CommandHandlers
{
    public class ProductCommandHandlers : 
        IRequestHandler<CreateProductCommand, Result<string>>,
        IRequestHandler<UpdateProductCommand, Result<string>>,
        IRequestHandler<UpdateProductStatusCommand, Result<string>>
    {
        private readonly IProductRepository _product;
        private readonly IProductGroupRepository _productGroup;
        private readonly IMapper _mapper;
        public ProductCommandHandlers(IProductRepository product, IProductGroupRepository productGroup, IMapper mapper)
        {
            _product = product;
            _productGroup = productGroup;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Convert request to product
            var newProduct = _mapper.Map<Product>(request);

            // Check if the newProduct is NULL
            if (newProduct is null)
                return Result<string>.Failure(ProductErrors.NullValue);

            // Check if the product group id is exist on the database
            if (await _productGroup.IsExistAsync(data => data.Id == request.ProductGroupId && data.Status != CommonStatus.Deleted))
                return Result<string>.Failure(ProductGroupErrors.NotFound(request.ProductGroupId));

            // Set other information
            newProduct.Status = CommonStatus.Active;
            newProduct.CreatedAt = DateTime.Now;
            newProduct.CreatedBy = request.Requestor;

            // Create & save new product
            var result = await _product.CreateProductAsync(newProduct);

            return Result<string>.Success($"Product created successfully. {result.Id}");
        }

        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Get product to be edit using productId
            var currentProduct = await _product.GetProductAsync(data => data.Id == request.ProductId);

            // Check if the product to be edit is existing
            if(currentProduct is null) 
                return Result<string>.Failure(ProductErrors.NotFound(request.ProductId));

            // Check if the product to be edit is already deleted
            if(currentProduct.Status == CommonStatus.Deleted) 
                return Result<string>.Failure(ProductErrors.AlreadyDeleted);

            // Check if the product group id is exist on the database
            if (await _productGroup.IsExistAsync(data => data.Id == request.ProductGroupId && data.Status != CommonStatus.Deleted))
                return Result<string>.Failure(ProductGroupErrors.NotFound(request.ProductGroupId));

            // Get updated product information
            var updatedProduct = _mapper.Map(request, currentProduct);
            updatedProduct.UpdatedAt = DateTime.Now;
            updatedProduct.UpdatedBy = request.Requestor;

            // Update & save product
            var result = await _product.UpdateProductAsync(updatedProduct);

            return Result<string>.Success($"Product updated successfully. {request.ProductId}");
        }

        public async Task<Result<string>> Handle(UpdateProductStatusCommand request, CancellationToken cancellationToken)
        {
            // Get product to be edit using productId
            var currentProduct = await _product.GetProductAsync(data => data.Id == request.ProductId);

            // Check if the product to be edit is existing
            if (currentProduct is null)
                return Result<string>.Failure(ProductErrors.NotFound(request.ProductId));

            // Check if the product to be edit is already deleted
            if (currentProduct.Status == CommonStatus.Deleted)
                return Result<string>.Failure(ProductErrors.AlreadyDeleted);

            // Update product status
            currentProduct.Status = request.NewStatus;
            currentProduct.UpdatedAt = DateTime.Now;
            currentProduct.UpdatedBy = request.Requestor;

            // Edit & save product
            var result = await _product.UpdateProductAsync(currentProduct);

            return Result<string>.Success($"Product status updated successfully. {request.ProductId}");
        }
    }
}
