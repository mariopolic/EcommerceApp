
using ECA.Infrastructure.Contexts;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Repositories.EF_Core;
using ECA.Infrastructure.Services.CustomerService;
using ECA.Infrastructure.Services.OrderItemService;
using ECA.Infrastructure.Services.OrderService;
using ECA.Infrastructure.Services.ProductService;
using Microsoft.EntityFrameworkCore;
using ECA.Infrastructure.extensions;
using AutoMapper;

namespace E_commerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // injecting repositories
            builder.Services.AddDbContext<EcommerceAppContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("EcomDb")));
            // Add services to the container.
            builder.Services.AddServices();
            builder.Services.AddRepositoryServices();
            builder.Services.AddValidators();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           
            app.MapControllers();

            app.Run();
        }
    }
}