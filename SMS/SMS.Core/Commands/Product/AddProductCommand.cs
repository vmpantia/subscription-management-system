using MediatR;
using SMS.Domain.Results;

namespace SMS.Core.Commands.Product
{
    public class AddProductCommand : IRequest<Result<string>>
    {
        public Guid ProductGroupId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Vendor { get; set; }
        public string VendorProductCode { get; set; }
        public string VendorContractTerm { get; set; }
        public string Manufacturer { get; set; }
        public string Requestor { get; set; }
    }
}
