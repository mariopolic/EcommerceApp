using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Repositories.EF_Core;
using Microsoft.Extensions.DependencyInjection;

namespace ECA.Infrastructure.extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            return services;
        }
    }
}
