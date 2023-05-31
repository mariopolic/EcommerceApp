using ECA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByNameAsync(string name);
        Task<Product> GetByPriceAsync(int price);
    }
}
