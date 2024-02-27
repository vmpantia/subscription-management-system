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

        public async Task<IEnumerable<Subscription>> GetSubscriptionsFullInfoAsync(Expression<Func<Subscription, bool>> expression) =>
            await FindByExpression(expression)
                    .Include(tbl => tbl.Product)
                        .ThenInclude(tbl => tbl.ProductGroup)
                            .ThenInclude(tbl => tbl.ProductType)
                    .AsSplitQuery()
                    .ToListAsync();

        public async Task<Subscription?> GetSubscriptionFullInfoAsync(Expression<Func<Subscription, bool>> expression)
        {
            var result = await GetSubscriptionsFullInfoAsync(expression);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(Expression<Func<Subscription, bool>> expression) =>
            await FindByExpression(expression).ToListAsync();

        public async Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> expression) =>
            await FindOneByExpressionAsync(expression);

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            await CreateAsync(subscription);
            await SaveAsync();

            return subscription;
        }

        public async Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {
            await UpdateAsync(subscription);
            await SaveAsync();

            return subscription;
        }
    }
}
