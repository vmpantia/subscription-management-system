using System.ComponentModel.DataAnnotations;

namespace SMS.Core.Models.Dtos.Subscription
{
    public class CreateSubscriptionDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public DateTime AnniversaryDate { get; set; }
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
    }
}
