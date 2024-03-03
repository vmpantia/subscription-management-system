namespace SMS.Core.Models.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryContactTelephone { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid? BillToCustomerId { get; set; }
        public string? BillToCustomerName { get; set; }
        public string? BillToCustomerCurrency { get; set; }
    }
}
