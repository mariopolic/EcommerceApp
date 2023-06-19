using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderRepository 
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByCustomerAsync(int Customerid);
    }
}
