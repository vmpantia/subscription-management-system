using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public DateTime AnnivesaryDate { get; set; }
        [Required]
        public DateTime ServicePeriodStartAt { get; set; }
        [Required]
        public DateTime ServicePeriodEndAt { get; set; }
        [Required]
        public DateTime ActivationDate { get; set; }
        [Required]
        public bool IsAutomaticRenewal { get; set; }
        [Required]
        public string PaymentCycle { get; set; }
        [Required]
        public string SubscriptionCycle { get; set; }
        [Required]
        public SubscriptionStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual Product Product { get; set; }
    }
}
