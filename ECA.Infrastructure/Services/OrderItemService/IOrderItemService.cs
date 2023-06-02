using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemResponseModel>> GetAllOrderItems();
        Task<OrderItemResponseModel> GetSingleOrderItem(int OrderId);
        Task<OrderItemResponseModel> AddOrderItem(int customerId,int orderId, OrderItemRequestModel orderItemRequest);
        Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderRequestModel orderRequest);
        Task<SuccessResponseModel> DeleteOrderItem(int customerId,int orderId);
    }
}
