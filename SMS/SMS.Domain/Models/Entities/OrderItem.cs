using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Guid? SubscriptionId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public DateTime? ServicePeriodStartAt { get; set; }
        public DateTime? ServicePeriodEndAt { get; set; }
        public DateTime? ActivationDate { get; set; }
        public bool? IsAutomaticRenewal { get; set; }
        [StringLength(100)]
        public string? PaymentCycle { get; set; }
        [StringLength(100)]
        public string? SubscriptionCycle { get; set; }
        [Required]
        public OrderItemType Type { get; set; }
        [Required]
        public CommonStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual Order Order { get; set; }
        public virtual Subscription? Subscription { get; set; }
        public virtual Product? Product { get; set; }
    }
}
