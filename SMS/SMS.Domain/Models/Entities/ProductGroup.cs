using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class ProductGroup
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductTypeId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string RenewalHandler { get; set; }
        [Required]
        public CommonStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
