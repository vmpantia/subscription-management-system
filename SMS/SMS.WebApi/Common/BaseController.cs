using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Exceptions;

namespace SMS.WebApi.Common
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async Task<IActionResult> HandleRequestAsync<TRequest>(TRequest request)
        {
            try
            {
                // Check if the request if NULL
                if(request == null)
                    throw new ArgumentNullException(nameof(request));

                // Process the request using mediator
                var result = await _mediator.Send(request);

                // Check if the result has value 
                if (result == null)
                    throw new DataNotFoundException("No result found after processing mediator.");

                return Ok(result);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
