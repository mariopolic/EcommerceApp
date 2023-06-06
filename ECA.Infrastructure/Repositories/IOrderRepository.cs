using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByCustomerAsync(int Customerid);
    }
}
