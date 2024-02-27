using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsFullInfoAsync(Expression<Func<Subscription, bool>> expression);
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(Expression<Func<Subscription, bool>> expression);
        Task<Subscription?> GetSubscriptionFullInfoAsync(Expression<Func<Subscription, bool>> expression);
        Task<Subscription?> GetSubscriptionAsync(Expression<Func<Subscription, bool>> expression);
        Task<Subscription> CreateSubscriptionAsync(Subscription product);
        Task<Subscription> UpdateSubscriptionAsync(Subscription product);
    }
}
