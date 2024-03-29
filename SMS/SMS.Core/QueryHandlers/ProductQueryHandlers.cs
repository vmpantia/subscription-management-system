﻿using AutoMapper;
using SMS.Core.Models.ViewModels.Product;
using SMS.Core.Queries.Product;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Results.Errors;
using SMS.Domain.Results;
using MediatR;
using SMS.Domain.Models.Enums;
using SMS.Domain.Models.Entities;

namespace SMS.Core.QueryHandlers
{
    public class ProductQueryHandlers : 
        IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductViewModel>>>,
        IRequestHandler<GetAllProductLitesQuery, Result<IEnumerable<ProductLiteViewModel>>>,
        IRequestHandler<GetProductByIdQuery, Result<ProductViewModel>>
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public ProductQueryHandlers(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _product.GetProductsFullInfoAsync(data => data.Status != CommonStatus.Deleted);

            if (result is null)
                return Result<IEnumerable<ProductViewModel>>.Failure(ProductErrors.NullValue);

            var dto = _mapper.Map<IEnumerable<ProductViewModel>>(result);
            return Result<IEnumerable<ProductViewModel>>.Success(dto);
        }

        public async Task<Result<IEnumerable<ProductLiteViewModel>>> Handle(GetAllProductLitesQuery request, CancellationToken cancellationToken)
        {
            var result = await _product.GetProductsAsync(data => data.Status == CommonStatus.Active);

            if (result is null)
                return Result<IEnumerable<ProductLiteViewModel>>.Failure(ProductErrors.NullValue);

            var dto = _mapper.Map<IEnumerable<ProductLiteViewModel>>(result);
            return Result<IEnumerable<ProductLiteViewModel>>.Success(dto);
        }

        public async Task<Result<ProductViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _product.GetProductFullInfoAsync(data => data.Id == request.Id && 
                                                                        data.Status != CommonStatus.Deleted);

            if (result is null)
                return Result<ProductViewModel>.Failure(ProductErrors.NotFound(request.Id));

            var dto = _mapper.Map<ProductViewModel>(result);
            return Result<ProductViewModel>.Success(dto);
        }
    }
}
