global using Microsoft.EntityFrameworkCore;
using ECA.Core.Models;

namespace ECA.Infrastructure.Contexts
{
    public  class EcommerceAppContext:DbContext 
    {
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-OABEERU8;Database=EcommerceAppDatabase;Trusted_Connection=True;Encrypt=false;");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
