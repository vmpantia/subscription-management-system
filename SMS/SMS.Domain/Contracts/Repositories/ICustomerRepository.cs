using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> IsExistAsync(Expression<Func<Customer, bool>> expression);
        Task<IEnumerable<Customer>> GetCustomersFullInfoAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer?> GetCustomerAsync(Expression<Func<Customer, bool>> expression);
    }
}