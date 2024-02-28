namespace SMS.Core.Models.ViewModels.Subscription
{
    public class SubscriptionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime AnniversaryDate { get; set; }
        public DateTime ServicePeriodStartAt { get; set; }
        public DateTime ServicePeriodEndAt { get; set; }
        public DateTime ActivationDate { get; set; }
        public bool IsAutomaticRenewal { get; set; }
        public string PaymentCycle { get; set; }
        public string SubscriptionCycle { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductVendor { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductTypeName { get; set; }
    }
}
