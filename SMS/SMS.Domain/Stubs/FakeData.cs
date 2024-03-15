using Bogus;
using Bogus.Extensions.UnitedStates;
using SMS.Domain.Models.Entities;
using SMS.Domain.Models.Enums;

namespace SMS.Domain.Stubs
{
    public class FakeData
    {
        public static List<string> _paymentAndSubscriptionCycles = new List<string> { "Yearly", "Monthly" };

        public static Faker<ProductType> FakerProductType() =>
            new Faker<ProductType>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<ProductGroup> FakerProductGroup(IEnumerable<Guid> productTypeIds) =>
            new Faker<ProductGroup>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.ProductTypeId, faker => faker.PickRandom(productTypeIds))
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.RenewalHandler, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<Product> FakerProduct(IEnumerable<Guid> productGroupIds) =>
             new Faker<Product>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.ProductGroupId, faker => faker.PickRandom(productGroupIds))
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Code, faker => faker.Company.Ein())
                .RuleFor(prop => prop.Description, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Vendor, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.VendorProductCode, faker => faker.Company.Ein())
                .RuleFor(prop => prop.VendorContractTerm, faker => faker.Company.Ein())
                .RuleFor(prop => prop.Manufacturer, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<Customer> FakerCustomer() =>
            new Faker<Customer>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.ShortName, faker => faker.Company.CompanySuffix())
                .RuleFor(prop => prop.Currency, faker => faker.Finance.Currency().Code)
                .RuleFor(prop => prop.Email, faker => faker.Internet.Email())
                .RuleFor(prop => prop.Telephone, faker => faker.Phone.PhoneNumber())
                .RuleFor(prop => prop.Address, faker => faker.Address.FullAddress())
                .RuleFor(prop => prop.PrimaryContactName, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.PrimaryContactEmail, faker => faker.Internet.Email())
                .RuleFor(prop => prop.PrimaryContactTelephone, faker => faker.Phone.PhoneNumber())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<Customer> FakerBillerCustomer(IEnumerable<Guid> customerIds) =>
            new Faker<Customer>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.BillToCustomerId, faker => faker.PickRandom(customerIds))
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.ShortName, faker => faker.Company.CompanySuffix())
                .RuleFor(prop => prop.Currency, faker => faker.Finance.Currency().Code)
                .RuleFor(prop => prop.Email, faker => faker.Internet.Email())
                .RuleFor(prop => prop.Telephone, faker => faker.Phone.PhoneNumber())
                .RuleFor(prop => prop.Address, faker => faker.Address.FullAddress())
                .RuleFor(prop => prop.PrimaryContactName, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.PrimaryContactEmail, faker => faker.Internet.Email())
                .RuleFor(prop => prop.PrimaryContactTelephone, faker => faker.Phone.PhoneNumber())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<Subscription> FakerSubscription(IEnumerable<Guid> productIds, IEnumerable<Guid> customerIds) =>
            new Faker<Subscription>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.ProductId, faker => faker.PickRandom(productIds))
                .RuleFor(prop => prop.CustomerId, faker => faker.PickRandom(customerIds))
                .RuleFor(prop => prop.Name, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.Description, faker => faker.Company.Ein())
                .RuleFor(prop => prop.Quantity, faker => faker.Random.Int())
                .RuleFor(prop => prop.UnitPrice, faker => faker.Random.Decimal())
                .RuleFor(prop => prop.AnniversaryDate, faker => faker.Date.Future())
                .RuleFor(prop => prop.ServicePeriodStartAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.ServicePeriodEndAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ActivationDate, faker => faker.Date.Past())
                .RuleFor(prop => prop.IsAutomaticRenewal, faker => faker.Random.Bool())
                .RuleFor(prop => prop.PaymentCycle, faker => faker.PickRandom(_paymentAndSubscriptionCycles))
                .RuleFor(prop => prop.SubscriptionCycle, faker => faker.PickRandom(_paymentAndSubscriptionCycles))
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<SubscriptionStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<Order> FakerOrder(IEnumerable<Guid> customerIds) => 
            new Faker<Order>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.CustomerId, faker => faker.PickRandom(customerIds))
                .RuleFor(prop => prop.OrderNumber, faker => faker.Company.Ein())
                .RuleFor(prop => prop.Remarks, faker => faker.Company.CompanyName())
                .RuleFor(prop => prop.NotificationStartAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ConfirmationDueAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ConfirmedAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ConfirmedBy, faker => faker.Internet.Email())
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<OrderStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

        public static Faker<OrderItem> FakerOrderItem(Order order, List<Subscription> subscriptions, List<Product> products)
        {
            var orderItem = new Faker<OrderItem>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.OrderId, order.Id)
                .RuleFor(prop => prop.Quantity, faker => faker.Random.Int())
                .RuleFor(prop => prop.UnitPrice, faker => faker.Random.Decimal())
                .RuleFor(prop => prop.AnniversaryDate, faker => faker.Date.Future())
                .RuleFor(prop => prop.ServicePeriodStartAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ServicePeriodEndAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.ActivationDate, faker => faker.Date.Future())
                .RuleFor(prop => prop.IsAutomaticRenewal, faker => faker.Random.Bool())
                .RuleFor(prop => prop.PaymentCycle, faker => faker.PickRandom(_paymentAndSubscriptionCycles))
                .RuleFor(prop => prop.SubscriptionCycle, faker => faker.PickRandom(_paymentAndSubscriptionCycles))
                .RuleFor(prop => prop.Status, faker => faker.PickRandom<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Past())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());

            var activeSubscriptions = subscriptions.Where(data => data.CustomerId == order.CustomerId &&
                                                                  data.Status == SubscriptionStatus.Active);

            if (activeSubscriptions.Any())
            {
                orderItem.RuleFor(prop => prop.SubscriptionId, faker => faker.PickRandom(activeSubscriptions).Id)
                         .RuleFor(prop => prop.Type, OrderItemType.Renewal);
            }
            else
            {
                var activeProducts = products.Where(data => data.Status == CommonStatus.Active);
                orderItem.RuleFor(prop => prop.ProductId, faker => faker.PickRandom(activeProducts).Id)
                         .RuleFor(prop => prop.Type, OrderItemType.New);
            }

            return orderItem;
        }
    }
}
