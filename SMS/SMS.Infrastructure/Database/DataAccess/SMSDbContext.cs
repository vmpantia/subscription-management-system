using Microsoft.EntityFrameworkCore;
using SMS.Domain.Models.Entities;
using SMS.Domain.Stubs;

namespace SMS.Infrastructure.Database.DataAccess
{
    public class SMSDbContext : DbContext
    {
        private readonly List<ProductType> _stubProductTypes = new List<ProductType>();
        private readonly List<ProductGroup> _stubProductGroups = new List<ProductGroup>();
        private readonly List<Product> _stubProduct = new List<Product>();
        private readonly List<Subscription> _stubSubscriptions = new List<Subscription>();
        private readonly List<Customer> _stubCustomers = new List<Customer>();
        public SMSDbContext(DbContextOptions options) : base(options)
        {
            #region Stub Data
            _stubProductTypes = FakeData.FakerProductType()
                                        .Generate(100);
            _stubProductGroups = FakeData.FakerProductGroup(_stubProductTypes.Select(data => data.Id))
                                         .Generate(100);
            _stubProduct = FakeData.FakerProduct(_stubProductGroups.Select(data => data.Id))
                                   .Generate(1000);

            var customer = FakeData.FakerCustomer()
                                   .Generate(200);
            var customerWithBiller = FakeData.FakerBillerCustomer(customer.Select(data => data.Id))
                                             .Generate(100);
            _stubCustomers.AddRange(customer);
            _stubCustomers.AddRange(customerWithBiller);

            _stubSubscriptions = FakeData.FakerSubscription(_stubProduct.Select(data => data.Id), _stubCustomers.Select(data => data.Id))
                                         .Generate(1000);
            #endregion
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

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

                // Indexing
                enty.HasIndex(props => new { props.Name, props.Code, props.Status });

                // Data Seeds
                enty.HasData(_stubProduct);
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

                // Indexing
                enty.HasIndex(props => new { props.Name, props.ShortName, props.Currency, props.Email, props.PrimaryContactEmail });

                // Data Seeds
                enty.HasData(_stubCustomers);
            });
        }
    }
}
