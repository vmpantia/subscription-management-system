using MediatR;
using SMS.Core.Models.Dtos;
using SMS.Domain.Models.Enums;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Product
{
    public class UpdateProductStatusCommand : IRequest<Result<string>>
    {
        public UpdateProductStatusCommand(Guid productId, UpdateProductStatusDto request, string requestor)
        {
            ProductId = productId;
            NewStatus = request.NewStatus;
            Requestor = requestor;
        }

        public Guid ProductId { get; init; }
        public CommonStatus NewStatus { get; init; }
        public string Requestor { get; init; }
    }
}
