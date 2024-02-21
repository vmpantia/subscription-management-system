using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindByExpression(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> FindByIdAsync(Expression<Func<TEntity, object>> primaryKeySelector);
        Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
