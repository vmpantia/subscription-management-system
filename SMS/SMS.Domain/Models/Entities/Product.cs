using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductGroupId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Code { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        [Required, StringLength(100)]
        public string Vendor { get; set; }
        [Required, StringLength(100)]
        public string VendorProductCode { get; set; }
        [Required, StringLength(100)]
        public string VendorContractTerm { get; set; }
        [Required, StringLength(100)]
        public string Manufacturer { get; set; }
        [Required]
        public CommonStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
