using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Domain.Contracts.Repositories;
using SMS.Infrastructure.Database.DataAccess;
using SMS.Infrastructure.Database.Repositories;

namespace SMS.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SMSDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
