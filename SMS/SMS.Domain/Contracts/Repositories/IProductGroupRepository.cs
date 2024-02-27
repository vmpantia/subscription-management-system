using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface IProductGroupRepository
    {
        Task<bool> IsExistAsync(Expression<Func<ProductGroup, bool>> expression);
    }
}