using Microsoft.EntityFrameworkCore;
using SMS.Domain.Contracts.Repositories;
using SMS.Infrastructure.Database.DataAccess;
using System.Linq.Expressions;

namespace SMS.Infrastructure.Database.Repositories
{
    public class BaseRepository <TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly SMSDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(SMSDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll() =>
            _table.AsNoTracking();

        public IQueryable<TEntity> FindByExpression(Expression<Func<TEntity, bool>> expression) =>
            _table.Where(expression).AsNoTracking();

        public async Task<TEntity?> FindByIdAsync(Expression<Func<TEntity, object>> primaryKeySelector) =>
            await _table.FindAsync(primaryKeySelector);

        public async Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression) =>
            await _table.FirstOrDefaultAsync(expression);

        public async Task AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _table.Update(entity); 
            await _context.SaveChangesAsync();
        }
    }
}
