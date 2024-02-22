using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Results;

namespace SMS.WebApi.Common
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async Task<IActionResult> HandleRequestAsync<TRequest, TResult>(TRequest request)
            where TRequest : class
            where TResult : class
        {
            try
            {
                // Check if the request is NULL
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                // Process the request using mediator
                var response = await _mediator.Send(request);

                // Check if the response is valid type of Result<TResult>
                if (!(response is Result<TResult> result))
                    throw new Exception($"Invalid result for a certain request {nameof(TResult)}.");

                return result switch
                {
                    { IsSuccess: false, Error: { Code: var errorCode } } when errorCode.Contains("NotFound") => NotFound(result),
                    { IsSuccess: false, Error: var error } => BadRequest(result),
                    _ => Ok(result)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
