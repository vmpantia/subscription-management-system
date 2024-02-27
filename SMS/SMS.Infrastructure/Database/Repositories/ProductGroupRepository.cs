using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Infrastructure.Database.DataAccess;
using System.Linq.Expressions;

namespace SMS.Infrastructure.Database.Repositories
{
    public class ProductGroupRepository : BaseRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(SMSDbContext context) : base(context) { }

        public async Task<bool> IsExistAsync(Expression<Func<ProductGroup, bool>> expression)
        {
            var result = await FindOneByExpressionAsync(expression);
            return result is not null;
        }
    }
}
