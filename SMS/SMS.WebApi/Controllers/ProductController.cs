using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Core.Models.ViewModels.Product;
using SMS.Core.Queries.Product;
using SMS.WebApi.Common;

namespace SMS.WebApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync() =>
            await HandleRequestAsync<GetAllProductsQuery, IEnumerable<ProductViewModel>>(new GetAllProductsQuery());

        [HttpGet("lites")]
        public async Task<IActionResult> GetAllProductLitesAsync() =>
            await HandleRequestAsync<GetAllProductLitesQuery, IEnumerable<ProductLiteViewModel>>(new GetAllProductLitesQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(Guid id) =>
            await HandleRequestAsync<GetProductByIdQuery, ProductViewModel>(new GetProductByIdQuery(id));
    }
}
