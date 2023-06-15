﻿global using Microsoft.EntityFrameworkCore;
using ECA.Core.Models;

namespace ECA.Infrastructure.Contexts
{
    public class EcommerceAppContext : DbContext
    {
        public EcommerceAppContext(DbContextOptions<EcommerceAppContext> options) : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Order)
                .HasForeignKey(o => o.CustomerId);


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                FirstName = "Faruk",
                LastName = "Sackin",
                Address = "Koliste",
                City = "Cazin",
                IsDeleted = false
            });
        }
    }
}
