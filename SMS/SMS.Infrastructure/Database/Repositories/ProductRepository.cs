using Microsoft.EntityFrameworkCore;
using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Infrastructure.Database.DataAccess;
using System.Linq.Expressions;

namespace SMS.Infrastructure.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SMSDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsFullInfoAsync(Expression<Func<Product, bool>> expression) =>
            await FindByExpression(expression)
                    .Include(tbl => tbl.ProductGroup)
                        .ThenInclude(tbl => tbl.ProductType)
                    .AsSplitQuery()
                    .ToListAsync();

        public async Task<Product?> GetProductFullInfoAsync(Expression<Func<Product, bool>> expression)
        {
            var result = await GetProductsFullInfoAsync(expression);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>> expression) =>
            await FindByExpression(expression).ToListAsync();

        public async Task<Product?> GetProductAsync(Expression<Func<Product, bool>> expression) =>
            await FindOneByExpressionAsync(expression);

        public async Task<Product> CreateProductAsync(Product product)
        {
            await CreateAsync(product);
            await SaveAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            await UpdateAsync(product);
            await SaveAsync();

            return product;
        }
    }
}
