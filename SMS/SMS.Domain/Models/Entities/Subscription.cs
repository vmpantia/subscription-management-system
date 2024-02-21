using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        [Required]
        public SubscriptionStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
