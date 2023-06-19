using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByCustomerAsync(int Customerid);
    }
}
