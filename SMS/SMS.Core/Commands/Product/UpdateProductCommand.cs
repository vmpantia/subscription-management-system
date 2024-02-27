using MediatR;
using SMS.Core.Models.Dtos;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Product
{
    public class UpdateProductCommand : CreateProductCommand, IRequest<Result<string>>
    {
        public UpdateProductCommand(Guid productId, UpdateProductDto request, string requestor) : base(request, requestor)
        {
            ProductId = productId;
            ProductGroupId = request.ProductGroupId;
            Name = request.Name;
            Code = request.Code;
            Description = request.Description;
            Vendor = request.Vendor;
            VendorProductCode = request.VendorProductCode;
            VendorContractTerm = request.VendorContractTerm;
            Manufacturer = request.Manufacturer;
            Requestor = requestor;
        }

        public Guid ProductId { get; init; }
    }
}
