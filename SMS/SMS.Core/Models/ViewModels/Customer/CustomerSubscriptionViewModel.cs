using SMS.Core.Models.ViewModels.Subscription;

namespace SMS.Core.Models.ViewModels.Customer
{
    public class CustomerSubscriptionViewModel : SubscriptionViewModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCurrency { get; set; }

        public Guid? BillToCustomerId { get; set; }
        public string? BillToCustomerName { get; set; }
        public string? BillToCustomerCurrency { get; set; }
    }
}
