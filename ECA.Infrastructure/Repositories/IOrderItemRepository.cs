using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;
using System.Linq.Expressions;

namespace ECA.Infrastructure.Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetByCustomerAsync(int Customerid);
        Task<OrderItem> GetByIdAsync(int id);
        Task<OrderItem> GetByProductIdAsync(int productid);
        Task<OrderItem> GetByPrice(int price);
        Task<OrderItem> AddAsync(OrderItem OrderItem);
        Task<OrderItem> UpdateAsync( OrderItem orderItem);
        Task<IEnumerable<OrderItem>> GetAsync(Expression<Func<OrderItem, bool>> predicate);
    }
}
