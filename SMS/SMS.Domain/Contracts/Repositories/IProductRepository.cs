using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductFullInfoAsync(Expression<Func<Product, bool>> expression);
        Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>> expression);
        Task<IEnumerable<Product>> GetProductsFullInfoAsync(Expression<Func<Product, bool>> expression);
    }
}