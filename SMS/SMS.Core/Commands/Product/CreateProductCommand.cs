using MediatR;
using SMS.Core.Models.Dtos.Product;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Product
{
    public class CreateProductCommand : IRequest<Result<string>>
    {
        public CreateProductCommand(CreateProductDto request, string requestor)
        {
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

        public Guid ProductGroupId { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
        public string? Description { get; init; }
        public string Vendor { get; init; }
        public string VendorProductCode { get; init; }
        public string VendorContractTerm { get; init; }
        public string Manufacturer { get; init; }
        public string Requestor { get; init; }
    }
}
