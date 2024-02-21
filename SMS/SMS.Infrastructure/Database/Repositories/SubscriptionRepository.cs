using Microsoft.EntityFrameworkCore;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Infrastructure.Database.DataAccess;
using System.Linq.Expressions;

namespace SMS.Infrastructure.Database.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(SMSDbContext context) : base(context) { }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(Expression<Func<Subscription, bool>> expression) =>
            await FindByExpression(expression).ToListAsync();
    }
}
