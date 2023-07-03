using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories
{
    public interface IProductRepository 
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByNameAsync(string name);
        Task<Product> GetByPriceAsync(int price);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>> predicate);
    }
}
