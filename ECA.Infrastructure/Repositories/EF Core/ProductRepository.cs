using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public IQueryable<Product> GetProducts()
        {
            return this.ecommerceAppContext.Products;
        }
        public async Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await GetProducts().Where(predicate).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            this.ecommerceAppContext.Products.Update(product);
            await this.ecommerceAppContext.SaveChangesAsync();
            return product;
        }
     
    }
}
