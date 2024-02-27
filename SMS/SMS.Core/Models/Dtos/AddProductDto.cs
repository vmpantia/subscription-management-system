using System.ComponentModel.DataAnnotations;

namespace SMS.Core.Models.Dtos
{
    public class AddProductDto
    {
        [Required]
        public Guid ProductGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public string VendorProductCode { get; set; }
        [Required]
        public string VendorContractTerm { get; set; }
        [Required]
        public string Manufacturer { get; set; }
    }
}
