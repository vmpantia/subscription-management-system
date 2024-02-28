using SMS.Core.Models.ViewModels.Subscription;

namespace SMS.Core.Models.ViewModels.Customer
{
    public class CustomerSubscriptionViewModel : SubscriptionViewModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCurrency { get; set; }

        public Guid? CustomerBillerId { get; set; }
        public string? CustomerBillerName { get; set; }
        public string? CustomerBillerCurrency { get; set; }
    }
}
