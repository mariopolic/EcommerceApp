using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public class OrderService : IOrderItemService
    {
        public Task<OrderItemResponseModel> AddOrderItem(int customerId, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessResponseModel> DeleteOrderItem(int customerId, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItemResponseModel>> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseModel> GetSingleOrderItem(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderRequestModel orderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
