using Microsoft.EntityFrameworkCore;
using SMS.Domain.Models.Entities;
using SMS.Domain.Stubs;

namespace SMS.Infrastructure.Database.DataAccess
{
    public class SMSDbContext : DbContext
    {
        private readonly List<Subscription> _stubSubscriptions = new List<Subscription>();
        public SMSDbContext(DbContextOptions options) : base(options)
        {
            _stubSubscriptions = FakeData.FakerSubscription()
                                         .Generate(1000);
        }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                        .HasData(_stubSubscriptions);
        }
    }
}
