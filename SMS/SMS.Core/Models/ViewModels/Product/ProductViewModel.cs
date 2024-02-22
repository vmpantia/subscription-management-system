namespace SMS.Core.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Vendor { get; set; }
        public string VendorProductCode { get; set; }
        public string VendorContractTerm { get; set; }
        public string Manufacturer { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductTypeName { get; set; }
    }
}
