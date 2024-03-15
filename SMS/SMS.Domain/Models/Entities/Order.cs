using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required, StringLength(15)]
        public string OrderNumber { get; set; }
        [StringLength(255)]
        public string? Remarks { get; set; }
        [Required]
        public DateTime NotificationStartAt { get; set; }
        [Required]
        public DateTime ConfirmationDueAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        [StringLength(50)]
        public string? ConfirmedBy { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
