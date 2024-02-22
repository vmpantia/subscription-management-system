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
                 await HandleRequestAsync<GetAllProductQuery, IEnumerable<ProductViewModel>>(new GetAllProductQuery());
    }
}
