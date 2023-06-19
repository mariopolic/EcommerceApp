using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Services.OrderService;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository itemRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderService orderService;
        public OrderItemService(IOrderItemRepository ItemRepository, ICustomerRepository CustomerRepository, IOrderService OrderService)
        {
            itemRepository = ItemRepository;
            customerRepository = CustomerRepository;
            orderService = OrderService;

        }

        public Task<OrderItemResponseModel> AddOrderItem(int customerId, int orderId, OrderItemRequestModel orderItemRequest)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessResponseModel> DeleteOrderItem(int orderId)
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

        public Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderItemRequestModel orderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
