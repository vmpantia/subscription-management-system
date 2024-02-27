using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Commands.Product;
using SMS.Core.Models.Dtos.Product;
using SMS.Core.Models.ViewModels.Product;
using SMS.Core.Queries.Product;
using SMS.WebApi.Common;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync() =>
            await HandleRequestAsync<GetAllProductsQuery, IEnumerable<ProductViewModel>>(new GetAllProductsQuery());

        [HttpGet("lites")]
        public async Task<IActionResult> GetAllProductLitesAsync() =>
            await HandleRequestAsync<GetAllProductLitesQuery, IEnumerable<ProductLiteViewModel>>(new GetAllProductLitesQuery());

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductAsync(Guid productId) =>
            await HandleRequestAsync<GetProductByIdQuery, ProductViewModel>(new GetProductByIdQuery(productId));

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductDto request) =>
            await HandleRequestAsync<CreateProductCommand, string>(new CreateProductCommand(request, string.Empty));

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(Guid productId, [FromForm] UpdateProductDto request) =>
            await HandleRequestAsync<UpdateProductCommand, string>(new UpdateProductCommand(productId, request, string.Empty));

        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProductStatusAsync(Guid productId, [FromForm] UpdateProductStatusDto request) =>
            await HandleRequestAsync<UpdateProductStatusCommand, string>(new UpdateProductStatusCommand(productId, request, string.Empty));
    }
}
