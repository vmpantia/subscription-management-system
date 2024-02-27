using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Core.Models.Dtos.Subscription
{
    public class UpdateSubscriptionStatusDto
    {
        [Required]
        public SubscriptionStatus NewStatus { get; set; }
    }
}
