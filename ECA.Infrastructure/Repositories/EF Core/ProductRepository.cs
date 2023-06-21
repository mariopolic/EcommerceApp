﻿using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public class ProductRepository :IProductRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public ProductRepository(EcommerceAppContext ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await GetProducts().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Product> AddAsync(Product product)
        {
            this.ecommerceAppContext.Products.Add(product);
            await this.ecommerceAppContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> GetByNameAsync(string name)
        {
            return await GetProducts().FirstOrDefaultAsync(c => c.ProductName == name);
        }

        public async Task<Product> GetByPriceAsync(int price)
        {
            return await GetProducts().FirstOrDefaultAsync(p=>p.ProductPrice == price);
        }
        private IQueryable<Product> GetProducts()
        {
            return this.ecommerceAppContext.Products;
        }
    }
}
