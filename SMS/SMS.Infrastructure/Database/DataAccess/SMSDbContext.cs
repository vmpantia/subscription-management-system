using Bogus;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Models.Entities;
using SMS.Domain.Stubs;

namespace SMS.Infrastructure.Database.DataAccess
{
    public class SMSDbContext : DbContext
    {
        private readonly List<ProductType> _stubProductTypes = new List<ProductType>();
        private readonly List<ProductGroup> _stubProductGroups = new List<ProductGroup>();
        private readonly List<Product> _stubProducts = new List<Product>();
        private readonly List<Subscription> _stubSubscriptions = new List<Subscription>();
        private readonly List<Customer> _stubCustomers = new List<Customer>();
        private readonly List<Order> _stubOrders = new List<Order>();
        private readonly List<OrderItem> _stubOrderItems = new List<OrderItem>();
        public SMSDbContext(DbContextOptions options) : base(options)
        {
            #region Stub Data
            // Generate Product Types Stub
            _stubProductTypes = FakeData.FakerProductType()
                                        .Generate(100);

            // Generate Product Groups Stub
            _stubProductGroups = FakeData.FakerProductGroup(_stubProductTypes.Select(data => data.Id))
                                         .Generate(100);

            // Generate Products Stub
            _stubProducts = FakeData.FakerProduct(_stubProductGroups.Select(data => data.Id))
                                    .Generate(1000);

            // Generate Customers Stub
            var customer = FakeData.FakerCustomer()
                                   .Generate(200);
            var customerWithBiller = FakeData.FakerBillerCustomer(customer.Select(data => data.Id))
                                             .Generate(100);
            _stubCustomers.AddRange(customer);
            _stubCustomers.AddRange(customerWithBiller);

            // Generate Subscriptions Stub
            _stubSubscriptions = FakeData.FakerSubscription(_stubProducts.Select(data => data.Id), _stubCustomers.Select(data => data.Id))
                                         .Generate(1000);

            // Generate Orders Stub
            _stubOrders = FakeData.FakerOrder(_stubCustomers.Select(data => data.Id))
                                  .Generate(500);

            // Generate Order Items Stub per Order
            _stubOrders.ForEach(order => _stubOrderItems.AddRange(FakeData.FakerOrderItem(order, _stubSubscriptions, _stubProducts)
                                                        .Generate(new Faker().Random.Int(1, 10))));
            #endregion
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>(enty =>
            {
                // Relationships
                enty.HasMany(prodT => prodT.ProductGroups)
                    .WithOne(prodG => prodG.ProductType)
                    .HasForeignKey(prodG => prodG.ProductTypeId)
                    .IsRequired();

                // Indexing
                enty.HasIndex(props => new { props.Name, props.Status });

                // Data Seeds
                enty.HasData(_stubProductTypes);
            });
            modelBuilder.Entity<ProductGroup>(enty =>
            {
                // Relationships
                enty.HasOne(prodG => prodG.ProductType)
                    .WithMany(prodT => prodT.ProductGroups)
                    .HasForeignKey(prodG => prodG.ProductTypeId)
                    .IsRequired();
                enty.HasMany(prodG => prodG.Products)
                    .WithOne(prod => prod.ProductGroup)
                    .HasForeignKey(prod => prod.ProductGroupId)
                    .IsRequired();

                // Indexing
                enty.HasIndex(props => new { props.Name, props.RenewalHandler, props.Status });

                // Data Seeds
                enty.HasData(_stubProductGroups);
            });
            modelBuilder.Entity<Product>(enty =>
            {
                // Relationships
                enty.HasOne(prod => prod.ProductGroup)
                    .WithMany(prodG => prodG.Products)
                    .HasForeignKey(prod => prod.ProductGroupId)
                    .IsRequired();
                enty.HasMany(prod => prod.Subscriptions)
                    .WithOne(subs => subs.Product)
                    .HasForeignKey(subs => subs.ProductId)
                    .IsRequired();
                enty.HasMany(prod => prod.OrderItems)
                    .WithOne(orderItem => orderItem.Product)
                    .HasForeignKey(orderItem => orderItem.ProductId)
                    .IsRequired(false);

                // Indexing
                enty.HasIndex(props => new { props.Name, props.Code, props.Status });

                // Data Seeds
                enty.HasData(_stubProducts);
            });
            modelBuilder.Entity<Subscription>(enty =>
            {
                // Value Conversion
                enty.Property(prop => prop.UnitPrice).HasColumnType("decimal(8,2)");

                // Relationships
                enty.HasOne(subs => subs.Product)
                    .WithMany(prod => prod.Subscriptions)
                    .HasForeignKey(subs => subs.ProductId)
                    .IsRequired();
                enty.HasOne(subs => subs.Customer)
                    .WithMany(prod => prod.Subscriptions)
                    .HasForeignKey(subs => subs.CustomerId)
                    .IsRequired();
                enty.HasMany(subs => subs.OrderItems)
                    .WithOne(orderItem => orderItem.Subscription)
                    .HasForeignKey(orderItem => orderItem.SubscriptionId)
                    .IsRequired(false);

                // Indexing
                enty.HasIndex(props => new { props.Name, props.IsAutomaticRenewal, props.Status, props.PaymentCycle, props.SubscriptionCycle });

                // Data Seeds
                enty.HasData(_stubSubscriptions);
            });
            modelBuilder.Entity<Customer>(enty =>
            {
                // Relationships
                enty.HasMany(cstmr => cstmr.Subscriptions)
                    .WithOne(subs => subs.Customer)
                    .HasForeignKey(subs => subs.CustomerId)
                    .IsRequired();
                enty.HasOne(cstmr => cstmr.BillToCustomer)
                    .WithMany(cstmr => cstmr.Customers)
                    .HasForeignKey(subs => subs.BillToCustomerId)
                    .IsRequired(false);
                enty.HasMany(cstmr => cstmr.Orders)
                    .WithOne(order => order.Customer)
                    .HasForeignKey(order => order.CustomerId)
                    .IsRequired(false);

                // Indexing
                enty.HasIndex(props => new { props.Name, props.ShortName, props.Currency, props.Email, props.PrimaryContactEmail });

                // Data Seeds
                enty.HasData(_stubCustomers);
            });
            modelBuilder.Entity<Order>(enty =>
            {
                // Relationships
                enty.HasOne(order => order.Customer)
                    .WithMany(cstmr => cstmr.Orders)
                    .HasForeignKey(order => order.CustomerId)
                    .IsRequired();
                enty.HasMany(order => order.OrderItems)
                    .WithOne(orderItem => orderItem.Order)
                    .HasForeignKey(orderItem => orderItem.OrderId)
                    .IsRequired();

                // Indexing
                enty.HasIndex(props => new { props.OrderNumber, props.Status });

                // Data Seeds
                enty.HasData(_stubOrders);
            });
            modelBuilder.Entity<OrderItem>(enty =>
            {
                // Value Conversion
                enty.Property(prop => prop.UnitPrice).HasColumnType("decimal(8,2)");

                // Relationships
                enty.HasOne(orderItem => orderItem.Order)
                    .WithMany(order => order.OrderItems)
                    .HasForeignKey(orderItem => orderItem.OrderId)
                    .IsRequired();
                enty.HasOne(orderItem => orderItem.Subscription)
                    .WithMany(subs => subs.OrderItems)
                    .HasForeignKey(orderItem => orderItem.SubscriptionId)
                    .IsRequired(false);
                enty.HasOne(orderItem => orderItem.Product)
                    .WithMany(prod => prod.OrderItems)
                    .HasForeignKey(orderItem => orderItem.ProductId)
                    .IsRequired(false);

                // Indexing
                enty.HasIndex(props => new { props.Status });

                // Data Seeds
                enty.HasData(_stubOrderItems);
            });
        }
    }
}
