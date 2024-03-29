﻿using ECA.Infrastructure.AutoMapper;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Repositories.EF_Core;
using ECA.Infrastructure.RequestModel;
using ECA.Infrastructure.Services.CustomerService;
using ECA.Infrastructure.Services.OrderItemService;
using ECA.Infrastructure.Services.OrderService;
using ECA.Infrastructure.Services.ProductService;
using ECA.Infrastructure.Validators;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ViewModels;
using FluentValidation;
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
            services.AddAutoMapper(typeof(ProductMappingProfile));
            return services;
        }

        public static IServiceCollection AddServices (this IServiceCollection services) 
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CustomerRequestModel>, CustomerRequestModelValidator>();
            services.AddTransient<IValidator<OrderRequestModel>, OrderRequestModelValidator>();
            services.AddTransient<IValidator<ProductRequestModel>, ProductRequestModelValidator>();
            services.AddTransient<IValidator<ProductPriceRangeRequestModel>, ProductPriceRangeValidator>();
            return services;
        }
    }
}
