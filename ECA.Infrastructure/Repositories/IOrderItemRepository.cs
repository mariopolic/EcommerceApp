using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderItemRepository : IRepository
    {
        Task<OrderItem> GetByCustomerAsync(int Customerid);
        Task<OrderItem> GetByIdAsync(int id);
        Task<OrderItem> GetByProductIdAsync(int productid);
        Task<OrderItem> GetByPrice(int price);

    }
}
