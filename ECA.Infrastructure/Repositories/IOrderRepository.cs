using ECA.Core.Models;
using System.Linq.Expressions;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderRepository 
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByCustomerAsync(int Customerid);
        Task<Order> AddAsync(Order Order);
        Task<IEnumerable<Order>> GetAsync(Expression<Func<Order, bool>> predicate);
        public Task<Order> UpdateAsync(Order order);
    }
}
