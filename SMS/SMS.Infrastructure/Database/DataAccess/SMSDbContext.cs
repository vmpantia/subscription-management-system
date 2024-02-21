using Microsoft.EntityFrameworkCore;
using SMS.Domain.Models.Entities;

namespace SMS.Infrastructure.Database.DataAccess
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
