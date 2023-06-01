using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetAllOrders();
        Task<OrderResponseModel> GetSingleOrder(int OrderId);
        Task<OrderResponseModel> AddOrder(int customerId);
        Task<OrderResponseModel> UpdateOrder(int OrderId, int customerId);
        Task<OrderResponseModel> DeleteOrder(int customerId);
    }
}
