
using ECA.Infrastructure.Contexts;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Repositories.EF_Core;
using ECA.Infrastructure.Services.CustomerService;

namespace E_commerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // injecting repositories
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddDbContext<EcommerceAppContext>();   

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