using ECA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderItemRepository:IRepository<OrderItem>
    {
        Task<OrderItem> GetByCustomerAsync(int Customerid);
        Task<OrderItem> GetByIdAsync(int id);
        Task<OrderItem> GetByProductIdAsync(int productid);
        Task<OrderItem> GetByPrice(int price);
        
    }
}
