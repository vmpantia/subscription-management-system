﻿using SMS.Domain.Contracts.Repositories;
using SMS.Domain.Models.Entities;
using SMS.Infrastructure.Database.DataAccess;
using System.Linq.Expressions;

namespace SMS.Infrastructure.Database.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SMSDbContext context) : base(context) { }

        public async Task<bool> IsExistAsync(Expression<Func<Customer, bool>> expression)
        {
            var result = await FindOneByExpressionAsync(expression);
            return result is not null;
        }
    }
}
