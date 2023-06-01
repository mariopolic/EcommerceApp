using ECA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByCustomerAsync(int Customerid);
    }
}
