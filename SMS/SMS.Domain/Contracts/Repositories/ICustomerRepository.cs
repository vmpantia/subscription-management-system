using SMS.Domain.Models.Entities;
using System.Linq.Expressions;

namespace SMS.Domain.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> IsExistAsync(Expression<Func<Customer, bool>> expression);
    }
}