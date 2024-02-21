using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(Expression<Func<Subscription, bool>> expression);
    }
}
