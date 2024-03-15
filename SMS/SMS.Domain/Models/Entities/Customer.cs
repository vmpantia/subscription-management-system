using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Domain.Models.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? BillToCustomerId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(20)]
        public string ShortName { get; set; }
        [Required, StringLength(20)]
        public string Currency { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Telephone { get; set; }
        [Required, StringLength(200)]
        public string Address { get; set; }
        [StringLength(100)]
        public string? PrimaryContactName { get; set; }
        [StringLength(100)]
        public string? PrimaryContactEmail { get; set; }
        [StringLength(100)]
        public string? PrimaryContactTelephone { get; set; }
        [Required]
        public CommonStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual Customer? BillToCustomer { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
